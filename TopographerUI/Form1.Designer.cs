namespace TopographerUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtWorldPath = new System.Windows.Forms.TextBox();
            this.btnOpenWorld = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radEnd = new System.Windows.Forms.RadioButton();
            this.radNether = new System.Windows.Forms.RadioButton();
            this.radOverworld = new System.Windows.Forms.RadioButton();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTransparency = new System.Windows.Forms.CheckBox();
            this.chkHeight = new System.Windows.Forms.CheckBox();
            this.chkBiomeFoliage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spnLimitHeight = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radTerrain = new System.Windows.Forms.RadioButton();
            this.radBiomes = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnLimitHeight)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWorldPath
            // 
            this.txtWorldPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorldPath.Location = new System.Drawing.Point(12, 12);
            this.txtWorldPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWorldPath.Name = "txtWorldPath";
            this.txtWorldPath.ReadOnly = true;
            this.txtWorldPath.Size = new System.Drawing.Size(425, 22);
            this.txtWorldPath.TabIndex = 0;
            // 
            // btnOpenWorld
            // 
            this.btnOpenWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWorld.Location = new System.Drawing.Point(443, 11);
            this.btnOpenWorld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenWorld.Name = "btnOpenWorld";
            this.btnOpenWorld.Size = new System.Drawing.Size(108, 23);
            this.btnOpenWorld.TabIndex = 1;
            this.btnOpenWorld.Text = "Open World";
            this.toolTip.SetToolTip(this.btnOpenWorld, "Select a world to render.");
            this.btnOpenWorld.UseVisualStyleBackColor = true;
            this.btnOpenWorld.Click += new System.EventHandler(this.btnOpenWorld_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radEnd);
            this.groupBox1.Controls.Add(this.radNether);
            this.groupBox1.Controls.Add(this.radOverworld);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(245, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimension";
            // 
            // radEnd
            // 
            this.radEnd.AutoSize = true;
            this.radEnd.Location = new System.Drawing.Point(184, 22);
            this.radEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radEnd.Name = "radEnd";
            this.radEnd.Size = new System.Drawing.Size(54, 21);
            this.radEnd.TabIndex = 2;
            this.radEnd.TabStop = true;
            this.radEnd.Text = "End";
            this.radEnd.UseVisualStyleBackColor = true;
            this.radEnd.CheckedChanged += new System.EventHandler(this.radEnd_CheckedChanged);
            // 
            // radNether
            // 
            this.radNether.AutoSize = true;
            this.radNether.Location = new System.Drawing.Point(107, 22);
            this.radNether.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radNether.Name = "radNether";
            this.radNether.Size = new System.Drawing.Size(72, 21);
            this.radNether.TabIndex = 1;
            this.radNether.TabStop = true;
            this.radNether.Text = "Nether";
            this.radNether.UseVisualStyleBackColor = true;
            this.radNether.CheckedChanged += new System.EventHandler(this.radNether_CheckedChanged);
            // 
            // radOverworld
            // 
            this.radOverworld.AutoSize = true;
            this.radOverworld.Checked = true;
            this.radOverworld.Location = new System.Drawing.Point(7, 22);
            this.radOverworld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radOverworld.Name = "radOverworld";
            this.radOverworld.Size = new System.Drawing.Size(93, 21);
            this.radOverworld.TabIndex = 0;
            this.radOverworld.TabStop = true;
            this.radOverworld.Text = "Overworld";
            this.radOverworld.UseVisualStyleBackColor = true;
            this.radOverworld.CheckedChanged += new System.EventHandler(this.radOverworld_CheckedChanged);
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRender.Enabled = false;
            this.btnRender.Location = new System.Drawing.Point(443, 39);
            this.btnRender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(108, 23);
            this.btnRender.TabIndex = 3;
            this.btnRender.Text = "Render";
            this.toolTip.SetToolTip(this.btnRender, "Generate and save a map of the chosen world.");
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 151);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(539, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTransparency);
            this.groupBox2.Controls.Add(this.chkHeight);
            this.groupBox2.Controls.Add(this.chkBiomeFoliage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.spnLimitHeight);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(539, 53);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkTransparency
            // 
            this.chkTransparency.AutoSize = true;
            this.chkTransparency.Checked = true;
            this.chkTransparency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransparency.Location = new System.Drawing.Point(372, 24);
            this.chkTransparency.Name = "chkTransparency";
            this.chkTransparency.Size = new System.Drawing.Size(118, 21);
            this.chkTransparency.TabIndex = 4;
            this.chkTransparency.Text = "Transparency";
            this.toolTip.SetToolTip(this.chkTransparency, "If checked areas beneath blocks such as water or glass will be visible.");
            this.chkTransparency.UseVisualStyleBackColor = true;
            // 
            // chkHeight
            // 
            this.chkHeight.AutoSize = true;
            this.chkHeight.Checked = true;
            this.chkHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeight.Location = new System.Drawing.Point(295, 24);
            this.chkHeight.Name = "chkHeight";
            this.chkHeight.Size = new System.Drawing.Size(71, 21);
            this.chkHeight.TabIndex = 3;
            this.chkHeight.Text = "Height";
            this.toolTip.SetToolTip(this.chkHeight, "If checked colors are made lighter or darker based on elevation.");
            this.chkHeight.UseVisualStyleBackColor = true;
            // 
            // chkBiomeFoliage
            // 
            this.chkBiomeFoliage.AutoSize = true;
            this.chkBiomeFoliage.Checked = true;
            this.chkBiomeFoliage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBiomeFoliage.Location = new System.Drawing.Point(170, 24);
            this.chkBiomeFoliage.Name = "chkBiomeFoliage";
            this.chkBiomeFoliage.Size = new System.Drawing.Size(119, 21);
            this.chkBiomeFoliage.TabIndex = 2;
            this.chkBiomeFoliage.Text = "Biome Foliage";
            this.toolTip.SetToolTip(this.chkBiomeFoliage, "If checked blocks such as grass will have their color vary based on biome.");
            this.chkBiomeFoliage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Limit Height:";
            this.toolTip.SetToolTip(this.label1, "Only render the world below the specified elevation.");
            // 
            // spnLimitHeight
            // 
            this.spnLimitHeight.Location = new System.Drawing.Point(97, 23);
            this.spnLimitHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spnLimitHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spnLimitHeight.Name = "spnLimitHeight";
            this.spnLimitHeight.Size = new System.Drawing.Size(56, 22);
            this.spnLimitHeight.TabIndex = 0;
            this.toolTip.SetToolTip(this.spnLimitHeight, "Only render the world below the specified elevation.");
            this.spnLimitHeight.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 400;
            this.toolTip.AutoPopDelay = 8000;
            this.toolTip.InitialDelay = 400;
            this.toolTip.ReshowDelay = 80;
            // 
            // radTerrain
            // 
            this.radTerrain.AutoSize = true;
            this.radTerrain.Checked = true;
            this.radTerrain.Location = new System.Drawing.Point(6, 22);
            this.radTerrain.Name = "radTerrain";
            this.radTerrain.Size = new System.Drawing.Size(75, 21);
            this.radTerrain.TabIndex = 0;
            this.radTerrain.TabStop = true;
            this.radTerrain.Text = "Terrain";
            this.toolTip.SetToolTip(this.radTerrain, "Render the terrain of the world normally.");
            this.radTerrain.UseVisualStyleBackColor = true;
            // 
            // radBiomes
            // 
            this.radBiomes.AutoSize = true;
            this.radBiomes.Location = new System.Drawing.Point(87, 22);
            this.radBiomes.Name = "radBiomes";
            this.radBiomes.Size = new System.Drawing.Size(75, 21);
            this.radBiomes.TabIndex = 1;
            this.radBiomes.Text = "Biomes";
            this.toolTip.SetToolTip(this.radBiomes, "Render a color coded map of biomes instead of the actual terrain.");
            this.radBiomes.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radBiomes);
            this.groupBox3.Controls.Add(this.radTerrain);
            this.groupBox3.Location = new System.Drawing.Point(263, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 53);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Render";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 179);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenWorld);
            this.Controls.Add(this.txtWorldPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Topographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnLimitHeight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorldPath;
        private System.Windows.Forms.Button btnOpenWorld;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radEnd;
        private System.Windows.Forms.RadioButton radNether;
        private System.Windows.Forms.RadioButton radOverworld;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown spnLimitHeight;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkTransparency;
        private System.Windows.Forms.CheckBox chkHeight;
        private System.Windows.Forms.CheckBox chkBiomeFoliage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radBiomes;
        private System.Windows.Forms.RadioButton radTerrain;
    }
}

