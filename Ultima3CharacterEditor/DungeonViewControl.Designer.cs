namespace Ultima3CharacterEditor
{
    partial class DungeonViewControl
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
            this.tableLayoutPanelTopLevel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSecondLevel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlDungeonLevel = new System.Windows.Forms.TabControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanelTopLevel.SuspendLayout();
            this.tableLayoutPanelSecondLevel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTopLevel
            // 
            this.tableLayoutPanelTopLevel.ColumnCount = 1;
            this.tableLayoutPanelTopLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTopLevel.Controls.Add(this.tableLayoutPanelSecondLevel, 0, 1);
            this.tableLayoutPanelTopLevel.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanelTopLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTopLevel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTopLevel.Name = "tableLayoutPanelTopLevel";
            this.tableLayoutPanelTopLevel.RowCount = 2;
            this.tableLayoutPanelTopLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTopLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTopLevel.Size = new System.Drawing.Size(718, 659);
            this.tableLayoutPanelTopLevel.TabIndex = 1;
            // 
            // tableLayoutPanelSecondLevel
            // 
            this.tableLayoutPanelSecondLevel.ColumnCount = 2;
            this.tableLayoutPanelSecondLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSecondLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelSecondLevel.Controls.Add(this.tabControlDungeonLevel, 0, 0);
            this.tableLayoutPanelSecondLevel.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanelSecondLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSecondLevel.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanelSecondLevel.Name = "tableLayoutPanelSecondLevel";
            this.tableLayoutPanelSecondLevel.RowCount = 1;
            this.tableLayoutPanelSecondLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSecondLevel.Size = new System.Drawing.Size(712, 628);
            this.tableLayoutPanelSecondLevel.TabIndex = 0;
            // 
            // tabControlDungeonLevel
            // 
            this.tabControlDungeonLevel.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlDungeonLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDungeonLevel.Location = new System.Drawing.Point(3, 3);
            this.tabControlDungeonLevel.Name = "tabControlDungeonLevel";
            this.tabControlDungeonLevel.SelectedIndex = 0;
            this.tabControlDungeonLevel.ShowToolTips = true;
            this.tabControlDungeonLevel.Size = new System.Drawing.Size(506, 622);
            this.tabControlDungeonLevel.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(515, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(194, 622);
            this.listView1.TabIndex = 3;
            this.listView1.TileSize = new System.Drawing.Size(30, 154);
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(718, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStripDungeonVC";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
          //  this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "Dungeon";
            // 
            // DungeonViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelTopLevel);
            this.Name = "DungeonViewControl";
            this.Size = new System.Drawing.Size(718, 659);
            this.tableLayoutPanelTopLevel.ResumeLayout(false);
            this.tableLayoutPanelTopLevel.PerformLayout();
            this.tableLayoutPanelSecondLevel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSecondLevel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.TabControl tabControlDungeonLevel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}
