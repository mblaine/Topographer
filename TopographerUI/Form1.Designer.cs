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
            this.label2 = new System.Windows.Forms.Label();
            this.spnLowerLimit = new System.Windows.Forms.NumericUpDown();
            this.chkTransparency = new System.Windows.Forms.CheckBox();
            this.chkHeight = new System.Windows.Forms.CheckBox();
            this.chkBiomeFoliage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spnUpperLimit = new System.Windows.Forms.NumericUpDown();
            this.txtBlockIDs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radExclude = new System.Windows.Forms.RadioButton();
            this.radOnly = new System.Windows.Forms.RadioButton();
            this.chkCrop = new System.Windows.Forms.CheckBox();
            this.cmbRotate = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radTerrain = new System.Windows.Forms.RadioButton();
            this.radBiomes = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkLessMemory = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnLowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpperLimit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.txtWorldPath.Size = new System.Drawing.Size(597, 22);
            this.txtWorldPath.TabIndex = 0;
            // 
            // btnOpenWorld
            // 
            this.btnOpenWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWorld.Location = new System.Drawing.Point(615, 11);
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
            this.btnRender.Location = new System.Drawing.Point(615, 39);
            this.btnRender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(108, 23);
            this.btnRender.TabIndex = 4;
            this.btnRender.Text = "Render";
            this.toolTip.SetToolTip(this.btnRender, "Generate and save a map of the chosen world.");
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 182);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(711, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.spnLowerLimit);
            this.groupBox2.Controls.Add(this.chkTransparency);
            this.groupBox2.Controls.Add(this.chkHeight);
            this.groupBox2.Controls.Add(this.chkBiomeFoliage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.spnUpperLimit);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(376, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lower Limit:";
            this.toolTip.SetToolTip(this.label2, "Only render the world above the specified elevation.");
            // 
            // spnLowerLimit
            // 
            this.spnLowerLimit.Location = new System.Drawing.Point(97, 49);
            this.spnLowerLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spnLowerLimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spnLowerLimit.Name = "spnLowerLimit";
            this.spnLowerLimit.Size = new System.Drawing.Size(56, 22);
            this.spnLowerLimit.TabIndex = 1;
            this.toolTip.SetToolTip(this.spnLowerLimit, "Only render the world above the specified elevation.");
            // 
            // chkTransparency
            // 
            this.chkTransparency.AutoSize = true;
            this.chkTransparency.Checked = true;
            this.chkTransparency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransparency.Location = new System.Drawing.Point(170, 47);
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
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upper Limit:";
            this.toolTip.SetToolTip(this.label1, "Only render the world below the specified elevation.");
            // 
            // spnUpperLimit
            // 
            this.spnUpperLimit.Location = new System.Drawing.Point(97, 23);
            this.spnUpperLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spnUpperLimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spnUpperLimit.Name = "spnUpperLimit";
            this.spnUpperLimit.Size = new System.Drawing.Size(56, 22);
            this.spnUpperLimit.TabIndex = 0;
            this.toolTip.SetToolTip(this.spnUpperLimit, "Only render the world below the specified elevation.");
            this.spnUpperLimit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // txtBlockIDs
            // 
            this.txtBlockIDs.Location = new System.Drawing.Point(82, 46);
            this.txtBlockIDs.Name = "txtBlockIDs";
            this.txtBlockIDs.Size = new System.Drawing.Size(96, 22);
            this.txtBlockIDs.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtBlockIDs, "An optional comma separated list of block IDs.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Block IDs:";
            this.toolTip.SetToolTip(this.label3, "An optional comma separated list of block IDs.");
            // 
            // radExclude
            // 
            this.radExclude.AutoSize = true;
            this.radExclude.Location = new System.Drawing.Point(82, 21);
            this.radExclude.Name = "radExclude";
            this.radExclude.Size = new System.Drawing.Size(78, 21);
            this.radExclude.TabIndex = 1;
            this.radExclude.Text = "Exclude";
            this.toolTip.SetToolTip(this.radExclude, "Render everything but blocks specified in the box to the right.");
            this.radExclude.UseVisualStyleBackColor = true;
            // 
            // radOnly
            // 
            this.radOnly.AutoSize = true;
            this.radOnly.Checked = true;
            this.radOnly.Location = new System.Drawing.Point(6, 21);
            this.radOnly.Name = "radOnly";
            this.radOnly.Size = new System.Drawing.Size(58, 21);
            this.radOnly.TabIndex = 0;
            this.radOnly.TabStop = true;
            this.radOnly.Text = "Only";
            this.toolTip.SetToolTip(this.radOnly, "Render only blocks specified in the box to the right.");
            this.radOnly.UseVisualStyleBackColor = true;
            // 
            // chkCrop
            // 
            this.chkCrop.AutoSize = true;
            this.chkCrop.Checked = true;
            this.chkCrop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCrop.Location = new System.Drawing.Point(6, 51);
            this.chkCrop.Name = "chkCrop";
            this.chkCrop.Size = new System.Drawing.Size(60, 21);
            this.chkCrop.TabIndex = 1;
            this.chkCrop.Text = "Crop";
            this.toolTip.SetToolTip(this.chkCrop, "If checked empty portions along the edges of the map are cropped.");
            this.chkCrop.UseVisualStyleBackColor = true;
            // 
            // cmbRotate
            // 
            this.cmbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRotate.FormattingEnabled = true;
            this.cmbRotate.Items.AddRange(new object[] {
            "Rotate 0°",
            "Rotate 90°",
            "Rotate 180°",
            "Rotate 270°"});
            this.cmbRotate.Location = new System.Drawing.Point(6, 21);
            this.cmbRotate.Name = "cmbRotate";
            this.cmbRotate.Size = new System.Drawing.Size(121, 24);
            this.cmbRotate.TabIndex = 0;
            this.toolTip.SetToolTip(this.cmbRotate, "How much the output map should be rotated.");
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
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Render";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtBlockIDs);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.radExclude);
            this.groupBox4.Controls.Add(this.radOnly);
            this.groupBox4.Location = new System.Drawing.Point(394, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 80);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Blocks";
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.chkCrop);
            this.grpOutput.Controls.Add(this.cmbRotate);
            this.grpOutput.Location = new System.Drawing.Point(584, 96);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(143, 80);
            this.grpOutput.TabIndex = 7;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkLessMemory);
            this.groupBox6.Location = new System.Drawing.Point(443, 39);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(166, 53);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Memory";
            // 
            // chkLessMemory
            // 
            this.chkLessMemory.AutoSize = true;
            this.chkLessMemory.Location = new System.Drawing.Point(6, 23);
            this.chkLessMemory.Name = "chkLessMemory";
            this.chkLessMemory.Size = new System.Drawing.Size(114, 21);
            this.chkLessMemory.TabIndex = 0;
            this.chkLessMemory.Text = "Less Memory";
            this.toolTip.SetToolTip(this.chkLessMemory, "Generate the map in such a way that less memory is used, however cropping and rot" +
        "ating isn\'t supported. May be necessary for worlds with 100s of regions.");
            this.chkLessMemory.UseVisualStyleBackColor = true;
            this.chkLessMemory.CheckedChanged += new System.EventHandler(this.chkLessMemory_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 210);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.groupBox4);
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
            ((System.ComponentModel.ISupportInitialize)(this.spnLowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpperLimit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown spnUpperLimit;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkTransparency;
        private System.Windows.Forms.CheckBox chkHeight;
        private System.Windows.Forms.CheckBox chkBiomeFoliage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radBiomes;
        private System.Windows.Forms.RadioButton radTerrain;
        private System.Windows.Forms.ComboBox cmbRotate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown spnLowerLimit;
        private System.Windows.Forms.CheckBox chkCrop;
        private System.Windows.Forms.RadioButton radOnly;
        private System.Windows.Forms.TextBox txtBlockIDs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radExclude;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkLessMemory;
    }
}

