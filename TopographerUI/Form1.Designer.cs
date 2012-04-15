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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spnLimitHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnLimitHeight)).BeginInit();
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
            this.txtWorldPath.Size = new System.Drawing.Size(503, 22);
            this.txtWorldPath.TabIndex = 0;
            // 
            // btnOpenWorld
            // 
            this.btnOpenWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWorld.Location = new System.Drawing.Point(521, 11);
            this.btnOpenWorld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.radEnd.Size = new System.Drawing.Size(72, 26);
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
            this.radNether.Size = new System.Drawing.Size(96, 26);
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
            this.radOverworld.Size = new System.Drawing.Size(124, 26);
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
            this.btnRender.Location = new System.Drawing.Point(521, 39);
            this.btnRender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.lblStatus.Location = new System.Drawing.Point(319, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(309, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.spnLimitHeight);
            this.groupBox2.Location = new System.Drawing.Point(263, 39);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(165, 53);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Limit Height:";
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
            this.spnLimitHeight.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 103);
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
    }
}

