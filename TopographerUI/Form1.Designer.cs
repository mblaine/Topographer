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
            this.txtWorldPath = new System.Windows.Forms.TextBox();
            this.btnOpenWorld = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radEnd = new System.Windows.Forms.RadioButton();
            this.radNether = new System.Windows.Forms.RadioButton();
            this.radOverworld = new System.Windows.Forms.RadioButton();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWorldPath
            // 
            this.txtWorldPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorldPath.Location = new System.Drawing.Point(12, 12);
            this.txtWorldPath.Name = "txtWorldPath";
            this.txtWorldPath.ReadOnly = true;
            this.txtWorldPath.Size = new System.Drawing.Size(447, 22);
            this.txtWorldPath.TabIndex = 0;
            // 
            // btnOpenWorld
            // 
            this.btnOpenWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWorld.Location = new System.Drawing.Point(465, 11);
            this.btnOpenWorld.Name = "btnOpenWorld";
            this.btnOpenWorld.Size = new System.Drawing.Size(108, 23);
            this.btnOpenWorld.TabIndex = 1;
            this.btnOpenWorld.Text = "Open World";
            this.btnOpenWorld.UseVisualStyleBackColor = true;
            this.btnOpenWorld.Click += new System.EventHandler(this.btnOpenWorld_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radEnd);
            this.groupBox1.Controls.Add(this.radNether);
            this.groupBox1.Controls.Add(this.radOverworld);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimension";
            // 
            // radEnd
            // 
            this.radEnd.AutoSize = true;
            this.radEnd.Location = new System.Drawing.Point(184, 22);
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
            this.radNether.Location = new System.Drawing.Point(106, 22);
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
            this.btnRender.Location = new System.Drawing.Point(465, 40);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(108, 23);
            this.btnRender.TabIndex = 3;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(263, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(310, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 103);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenWorld);
            this.Controls.Add(this.txtWorldPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Topographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

