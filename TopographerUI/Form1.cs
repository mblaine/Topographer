using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Topographer;

namespace TopographerUI
{
    public partial class Form1 : Form
    {
        private String lastWorldPath = String.Format("{0}{1}.minecraft{1}saves", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.DirectorySeparatorChar);
        private String lastSavePath = AppDomain.CurrentDomain.BaseDirectory;
        private Dimension dim = Dimension.Overworld;
        private Thread worker = null;

        private String regionPath = "";

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnRender;
            this.cmbRotate.SelectedIndex = 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            else if (keyData == (Keys.O | Keys.Control))
            {
                btnOpenWorld_Click(this, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EnableControls(bool enable)
        {
            foreach(Control c in this.Controls)
            {
                if (enable && c == grpOutput)
                    c.Enabled = !chkLessMemory.Checked;
                else if(!(c is Label))
                    c.Enabled = enable;
            }
        }

        private void CheckForRegions()
        {
            if (txtWorldPath.Text.Length == 0)
                return;
            regionPath = Path.GetDirectoryName(txtWorldPath.Text);
            if (Directory.Exists(String.Format("{0}{1}region", regionPath, Path.DirectorySeparatorChar)))
            {
                switch (dim)
                {
                    case Dimension.Overworld:
                        regionPath = String.Format("{0}{1}region", regionPath, Path.DirectorySeparatorChar);
                        break;
                    case Dimension.Nether:
                        regionPath = String.Format("{0}{1}DIM-1{1}region", regionPath, Path.DirectorySeparatorChar);
                        break;
                    case Dimension.End:
                        regionPath = String.Format("{0}{1}DIM1{1}region", regionPath, Path.DirectorySeparatorChar);
                        break;
                }
            }
            else
            {
                switch (dim)
                {
                    case Dimension.Overworld:
                        regionPath = String.Format("{0}{1}worlds{1}overworld{1}regions", regionPath, Path.DirectorySeparatorChar);
                        break;
                    case Dimension.Nether:
                        regionPath = String.Format("{0}{1}worlds{1}nether{1}regions", regionPath, Path.DirectorySeparatorChar);
                        break;
                    case Dimension.End:
                        regionPath = String.Format("{0}{1}worlds{1}the_end{1}regions", regionPath, Path.DirectorySeparatorChar);
                        break;
                }
            }

            if (Renderer.GetRegionCount(regionPath) > 0)
                btnRender.Enabled = true;
            else
                btnRender.Enabled = false;
        }

        private void UpdateStatus(String s)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Renderer.UpdateStatus(UpdateStatus), s);
                return;
            }

            lblStatus.Text = s;
            lblStatus.Refresh();
        }

        private void ThreadDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Renderer.DoneCallback(ThreadDone));
                return;
            }

            EnableControls(true);
            worker = null;
        }

        private void btnOpenWorld_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = lastWorldPath;
            dialog.Filter = "Minecraft level (*.dat)|*.dat";
            dialog.RestoreDirectory = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            lastWorldPath = Path.GetDirectoryName(dialog.FileName);
            txtWorldPath.Text = dialog.FileName;

            CheckForRegions();
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            HashSet<byte> set = null;
            if (txtBlockIDs.Text.Trim().Length > 0)
            {
                String[] ids = txtBlockIDs.Text.Split(new char[] { ',' });
                set = new HashSet<byte>();
                foreach (String id in ids)
                {
                    byte b;
                    if (byte.TryParse(id, out b))
                    {
                        set.Add(b);
                    }
                    else
                    {
                        MessageBox.Show(this, String.Format("\"Block IDs\" must be empty or a comma seperated list of block ids each between 0 and 255. Unable to parse\"{0}\".", id), "Topographer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = lastSavePath;
            dialog.FileName = String.Format("{0}{1}{2}.png", Path.GetFileName(lastWorldPath), dim != Dimension.Overworld ? "." + dim.ToString().ToLower() : "", radBiomes.Checked ? ".biomes" : "");
            dialog.Filter = "PNG (*.png)|*.png";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            lastSavePath = Path.GetDirectoryName(dialog.FileName);

            EnableControls(false);

            Renderer r = new Renderer(regionPath, dialog.FileName, UpdateStatus, ThreadDone);
            r.UpperLimit = (int)spnUpperLimit.Value;
            r.LowerLimit = (int)spnLowerLimit.Value;
            r.ConsiderBiomes = chkBiomeFoliage.Checked;
            r.ShowHeight = chkHeight.Checked;
            r.Transparency = chkTransparency.Checked;
            r.BiomeOverlay = radBiomes.Checked;
            r.LessMemory = chkLessMemory.Checked;
            switch ((String)cmbRotate.SelectedItem)
            {
                case "Rotate 90°":
                    r.Rotate = 90;
                    break;
                case "Rotate 180°":
                    r.Rotate = 180;
                    break;
                case "Rotate 270°":
                    r.Rotate = 270;
                    break;
                default:
                    r.Rotate = 0;
                    break;
            }
            r.CropMap = chkCrop.Checked;
            if (radOnly.Checked)
                r.Only = set;
            else
                r.Exclude = set;

            worker = new Thread(new ThreadStart(r.Render));
            worker.Start();
        }

        private void radOverworld_CheckedChanged(object sender, EventArgs e)
        {
            if (radOverworld.Checked)
            {
                dim = Dimension.Overworld;
                CheckForRegions();
            }
        }

        private void radNether_CheckedChanged(object sender, EventArgs e)
        {
            if (radNether.Checked)
            {
                dim = Dimension.Nether;
                CheckForRegions();
            }
        }

        private void radEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (radEnd.Checked)
            {
                dim = Dimension.End;
                CheckForRegions();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker != null && worker.IsAlive)
            {
                DialogResult res = MessageBox.Show(this, "A render is still in progress. Are you sure you want to quit?", "Topographer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    worker.Abort();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkLessMemory_CheckedChanged(object sender, EventArgs e)
        {
            grpOutput.Enabled = !chkLessMemory.Checked;
        }

    }
}
