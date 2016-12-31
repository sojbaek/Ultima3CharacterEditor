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
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControlCharacterEditor.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1411, 33);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.loadToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 1139);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1411, 28);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControlCharacterEditor
            // 
            this.tabControlCharacterEditor.Controls.Add(this.tabPageCharacterControl);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageMapViewer);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageDungeonViewer);
            this.tabControlCharacterEditor.Controls.Add(this.tabPageAbout);
            this.tabControlCharacterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCharacterEditor.Location = new System.Drawing.Point(3, 3);
            this.tabControlCharacterEditor.Name = "tabControlCharacterEditor";
            this.tabControlCharacterEditor.SelectedIndex = 0;
            this.tabControlCharacterEditor.Size = new System.Drawing.Size(1405, 1133);
            this.tabControlCharacterEditor.TabIndex = 6;
            // 
            // tabPageCharacterControl
            // 
            this.tabPageCharacterControl.Location = new System.Drawing.Point(4, 29);
            this.tabPageCharacterControl.Name = "tabPageCharacterControl";
            this.tabPageCharacterControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCharacterControl.Size = new System.Drawing.Size(1397, 1100);
            this.tabPageCharacterControl.TabIndex = 0;
            this.tabPageCharacterControl.Text = "Character Editor";
            this.tabPageCharacterControl.UseVisualStyleBackColor = true;
            // 
            // tabPageMapViewer
            // 
            this.tabPageMapViewer.Location = new System.Drawing.Point(4, 29);
            this.tabPageMapViewer.Name = "tabPageMapViewer";
            this.tabPageMapViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMapViewer.Size = new System.Drawing.Size(1397, 1100);
            this.tabPageMapViewer.TabIndex = 1;
            this.tabPageMapViewer.Text = "Map Viewer";
            this.tabPageMapViewer.UseVisualStyleBackColor = true;
            // 
            // tabPageDungeonViewer
            // 
            this.tabPageDungeonViewer.Location = new System.Drawing.Point(4, 29);
            this.tabPageDungeonViewer.Name = "tabPageDungeonViewer";
            this.tabPageDungeonViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDungeonViewer.Size = new System.Drawing.Size(1397, 1100);
            this.tabPageDungeonViewer.TabIndex = 2;
            this.tabPageDungeonViewer.Text = "Dungeon Viewer";
            this.tabPageDungeonViewer.UseVisualStyleBackColor = true;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 29);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(1397, 1100);
            this.tabPageAbout.TabIndex = 3;
            this.tabPageAbout.Text = "About...";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tabControlCharacterEditor, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1411, 1170);
            this.tableLayoutPanelMain.TabIndex = 7;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterEditorToolStripMenuItem,
            this.mapViewerToolStripMenuItem,
            this.dungeonViewerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // characterEditorToolStripMenuItem
            // 
            this.characterEditorToolStripMenuItem.Name = "characterEditorToolStripMenuItem";
            this.characterEditorToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.characterEditorToolStripMenuItem.Text = "Character Editor";
            // 
            // dungeonViewerToolStripMenuItem
            // 
            this.dungeonViewerToolStripMenuItem.Name = "dungeonViewerToolStripMenuItem";
            this.dungeonViewerToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.dungeonViewerToolStripMenuItem.Text = "Dungeon Viewer";
            // 
            // mapViewerToolStripMenuItem
            // 
            this.mapViewerToolStripMenuItem.Name = "mapViewerToolStripMenuItem";
            this.mapViewerToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.mapViewerToolStripMenuItem.Text = "Map Viewer";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 1203);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Ultima 3 Character Editor 0.2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlCharacterEditor.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonViewerToolStripMenuItem;
    }
}

