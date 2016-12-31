namespace Ultima3CharacterEditor
{
    partial class U3CharacterEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GrpBoxPlayerInfo = new System.Windows.Forms.GroupBox();
            this.dgvRoster = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Race = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartyInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonOnFoot = new System.Windows.Forms.RadioButton();
            this.radioButtonHorse = new System.Windows.Forms.RadioButton();
            this.radioButtonFrigate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPosY = new System.Windows.Forms.TextBox();
            this.textBoxPosX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.tabControlCharacterEditor = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.GrpBoxPlayerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoster)).BeginInit();
            this.PartyInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlCharacterEditor);
            this.splitContainer1.Size = new System.Drawing.Size(1039, 749);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GrpBoxPlayerInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PartyInfo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(240, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 745);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // GrpBoxPlayerInfo
            // 
            this.GrpBoxPlayerInfo.Controls.Add(this.dgvRoster);
            this.GrpBoxPlayerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBoxPlayerInfo.Location = new System.Drawing.Point(3, 3);
            this.GrpBoxPlayerInfo.Name = "GrpBoxPlayerInfo";
            this.GrpBoxPlayerInfo.Size = new System.Drawing.Size(257, 154);
            this.GrpBoxPlayerInfo.TabIndex = 3;
            this.GrpBoxPlayerInfo.TabStop = false;
            this.GrpBoxPlayerInfo.Text = "Players";
            // 
            // dgvRoster
            // 
            this.dgvRoster.AllowUserToAddRows = false;
            this.dgvRoster.AllowUserToDeleteRows = false;
            this.dgvRoster.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.Gender,
            this.Race,
            this.Profession});
            this.dgvRoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoster.Location = new System.Drawing.Point(3, 16);
            this.dgvRoster.Name = "dgvRoster";
            this.dgvRoster.ReadOnly = true;
            this.dgvRoster.RowHeadersWidth = 45;
            this.dgvRoster.Size = new System.Drawing.Size(251, 135);
            this.dgvRoster.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.FillWeight = 20F;
            this.Gender.HeaderText = "S";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 23;
            // 
            // Race
            // 
            this.Race.FillWeight = 20F;
            this.Race.HeaderText = "R";
            this.Race.Name = "Race";
            this.Race.ReadOnly = true;
            this.Race.Width = 23;
            // 
            // Profession
            // 
            this.Profession.FillWeight = 20F;
            this.Profession.HeaderText = "P";
            this.Profession.Name = "Profession";
            this.Profession.ReadOnly = true;
            this.Profession.Width = 23;
            // 
            // PartyInfo
            // 
            this.PartyInfo.Controls.Add(this.tableLayoutPanel2);
            this.PartyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartyInfo.Location = new System.Drawing.Point(3, 163);
            this.PartyInfo.Name = "PartyInfo";
            this.PartyInfo.Size = new System.Drawing.Size(257, 580);
            this.PartyInfo.TabIndex = 1;
            this.PartyInfo.TabStop = false;
            this.PartyInfo.Text = "Party";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxStatus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 561);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.AutoSize = true;
            this.groupBoxStatus.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatus.Location = new System.Drawing.Point(3, 3);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(245, 74);
            this.groupBoxStatus.TabIndex = 9;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.radioButtonOnFoot);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonHorse);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonFrigate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 55);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // radioButtonOnFoot
            // 
            this.radioButtonOnFoot.AutoSize = true;
            this.radioButtonOnFoot.Image = global::Ultima3CharacterEditor.Properties.Resources.ranger32;
            this.radioButtonOnFoot.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radioButtonOnFoot.Location = new System.Drawing.Point(3, 3);
            this.radioButtonOnFoot.Name = "radioButtonOnFoot";
            this.radioButtonOnFoot.Size = new System.Drawing.Size(63, 49);
            this.radioButtonOnFoot.TabIndex = 0;
            this.radioButtonOnFoot.TabStop = true;
            this.radioButtonOnFoot.Text = "On Foot";
            this.radioButtonOnFoot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButtonOnFoot.UseVisualStyleBackColor = true;
            this.radioButtonOnFoot.CheckedChanged += new System.EventHandler(this.radioButtonOnFoot_CheckedChanged);
            // 
            // radioButtonHorse
            // 
            this.radioButtonHorse.AutoSize = true;
            this.radioButtonHorse.Image = global::Ultima3CharacterEditor.Properties.Resources.horse32;
            this.radioButtonHorse.Location = new System.Drawing.Point(72, 3);
            this.radioButtonHorse.Name = "radioButtonHorse";
            this.radioButtonHorse.Size = new System.Drawing.Size(53, 49);
            this.radioButtonHorse.TabIndex = 2;
            this.radioButtonHorse.TabStop = true;
            this.radioButtonHorse.Text = "Horse";
            this.radioButtonHorse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButtonHorse.UseVisualStyleBackColor = true;
            this.radioButtonHorse.CheckedChanged += new System.EventHandler(this.radioButtonHorse_CheckedChanged);
            // 
            // radioButtonFrigate
            // 
            this.radioButtonFrigate.AutoSize = true;
            this.radioButtonFrigate.Image = global::Ultima3CharacterEditor.Properties.Resources.frigate32;
            this.radioButtonFrigate.Location = new System.Drawing.Point(131, 3);
            this.radioButtonFrigate.Name = "radioButtonFrigate";
            this.radioButtonFrigate.Size = new System.Drawing.Size(57, 49);
            this.radioButtonFrigate.TabIndex = 1;
            this.radioButtonFrigate.TabStop = true;
            this.radioButtonFrigate.Text = "Frigate";
            this.radioButtonFrigate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButtonFrigate.UseVisualStyleBackColor = true;
            this.radioButtonFrigate.CheckedChanged += new System.EventHandler(this.radioButtonFrigate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxPosY, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxPosX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(239, 52);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // textBoxPosY
            // 
            this.textBoxPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPosY.Location = new System.Drawing.Point(43, 29);
            this.textBoxPosY.Name = "textBoxPosY";
            this.textBoxPosY.Size = new System.Drawing.Size(193, 20);
            this.textBoxPosY.TabIndex = 9;
            this.textBoxPosY.TextChanged += new System.EventHandler(this.OnPartyValueChangedY);
            // 
            // textBoxPosX
            // 
            this.textBoxPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPosX.Location = new System.Drawing.Point(43, 3);
            this.textBoxPosX.Name = "textBoxPosX";
            this.textBoxPosX.Size = new System.Drawing.Size(193, 20);
            this.textBoxPosX.TabIndex = 8;
            this.textBoxPosX.TextChanged += new System.EventHandler(this.OnPartyValueChangedX);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxSteps, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 160);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(245, 26);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Steps";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSteps.Location = new System.Drawing.Point(43, 3);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(199, 20);
            this.textBoxSteps.TabIndex = 3;
            this.textBoxSteps.TextChanged += new System.EventHandler(this.OnPartyValueChangedSteps);
            // 
            // tabControlCharacterEditor
            // 
            this.tabControlCharacterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCharacterEditor.Location = new System.Drawing.Point(0, 0);
            this.tabControlCharacterEditor.Name = "tabControlCharacterEditor";
            this.tabControlCharacterEditor.SelectedIndex = 0;
            this.tabControlCharacterEditor.Size = new System.Drawing.Size(764, 745);
            this.tabControlCharacterEditor.TabIndex = 4;
            // 
            // U3CharacterEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "U3CharacterEditorControl";
            this.Size = new System.Drawing.Size(1039, 749);
            this.Load += new System.EventHandler(this.U3CharacterEditorControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GrpBoxPlayerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoster)).EndInit();
            this.PartyInfo.ResumeLayout(false);
            this.PartyInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox GrpBoxPlayerInfo;
        private System.Windows.Forms.DataGridView dgvRoster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Race;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profession;
        private System.Windows.Forms.GroupBox PartyInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonOnFoot;
        private System.Windows.Forms.RadioButton radioButtonHorse;
        private System.Windows.Forms.RadioButton radioButtonFrigate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxPosY;
        private System.Windows.Forms.TextBox textBoxPosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.TabControl tabControlCharacterEditor;
    }
}
