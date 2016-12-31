namespace Ultima3CharacterEditor
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControlCharacterEditor = new System.Windows.Forms.TabControl();
            this.tabPageCharacterControl = new System.Windows.Forms.TabPage();
            this.tabPageMapViewer = new System.Windows.Forms.TabPage();
            this.tabPageDungeonViewer = new System.Windows.Forms.TabPage();
            this.tabPageSpells = new System.Windows.Forms.TabPage();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.spellsViewControl = new Ultima3CharacterEditor.SpellsViewControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControlCharacterEditor.SuspendLayout();
            this.tabPageSpells.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(941, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loadToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(941, 18);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControlCharacterEditor
            // 
            this.tabControlCharacterEditor.Controls.Add(this.tabPageCharacterControl);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageMapViewer);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageDungeonViewer);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageSpells);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageAbout);
            this.tabControlCharacterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCharacterEditor.Location = new System.Drawing.Point(2, 2);
            this.tabControlCharacterEditor.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlCharacterEditor.Name = "tabControlCharacterEditor";
            this.tabControlCharacterEditor.SelectedIndex = 0;
            this.tabControlCharacterEditor.Size = new System.Drawing.Size(937, 714);
            this.tabControlCharacterEditor.TabIndex = 6;
            // 
            // tabPageCharacterControl
            // 
            this.tabPageCharacterControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageCharacterControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCharacterControl.Name = "tabPageCharacterControl";
            this.tabPageCharacterControl.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageCharacterControl.Size = new System.Drawing.Size(929, 688);
            this.tabPageCharacterControl.TabIndex = 0;
            this.tabPageCharacterControl.Text = "Character Editor";
            this.tabPageCharacterControl.UseVisualStyleBackColor = true;
            // 
            // tabPageMapViewer
            // 
            this.tabPageMapViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageMapViewer.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMapViewer.Name = "tabPageMapViewer";
            this.tabPageMapViewer.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMapViewer.Size = new System.Drawing.Size(929, 688);
            this.tabPageMapViewer.TabIndex = 1;
            this.tabPageMapViewer.Text = "Map Viewer";
            this.tabPageMapViewer.UseVisualStyleBackColor = true;
            // 
            // tabPageDungeonViewer
            // 
            this.tabPageDungeonViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageDungeonViewer.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageDungeonViewer.Name = "tabPageDungeonViewer";
            this.tabPageDungeonViewer.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageDungeonViewer.Size = new System.Drawing.Size(929, 688);
            this.tabPageDungeonViewer.TabIndex = 2;
            this.tabPageDungeonViewer.Text = "Dungeon Viewer";
            this.tabPageDungeonViewer.UseVisualStyleBackColor = true;
            // 
            // tabPageSpells
            // 
            this.tabPageSpells.Controls.Add(this.spellsViewControl);
            this.tabPageSpells.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpells.Name = "tabPageSpells";
            this.tabPageSpells.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpells.Size = new System.Drawing.Size(929, 688);
            this.tabPageSpells.TabIndex = 4;
            this.tabPageSpells.Text = "Spells";
            this.tabPageSpells.UseVisualStyleBackColor = true;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Size = new System.Drawing.Size(929, 688);
            this.tabPageAbout.TabIndex = 3;
            this.tabPageAbout.Text = "About...";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tabControlCharacterEditor, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.statusStrip1, 2, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(941, 738);
            this.tableLayoutPanelMain.TabIndex = 7;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 13);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(895, 13);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spellsViewControl
            // 
            this.spellsViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellsViewControl.Location = new System.Drawing.Point(3, 3);
            this.spellsViewControl.Name = "spellsViewControl";
            this.spellsViewControl.Size = new System.Drawing.Size(923, 682);
            this.spellsViewControl.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 762);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Ultima 3 Character Editor 0.2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlCharacterEditor.ResumeLayout(false);
            this.tabPageSpells.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterNames;
        private UserControlCharacter ucCharacter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlCharacterEditor;
        private System.Windows.Forms.TabPage tabPageCharacterControl;
        private System.Windows.Forms.TabPage tabPageMapViewer;
        private System.Windows.Forms.TabPage tabPageDungeonViewer;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TabPage tabPageSpells;
        private SpellsViewControl spellsViewControl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

