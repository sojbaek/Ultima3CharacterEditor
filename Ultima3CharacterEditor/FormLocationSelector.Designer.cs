namespace Ultima3CharacterEditor
{
    partial class UserControlLocationSelector
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

        public UserControlLocationSelector()
        {
            this.doc = null;
            InitializeComponent();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlLocationSelector));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonShip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonChest = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPos7 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonShip,
            this.toolStripButtonChest,
            this.toolStripButton8,
            this.toolStripPos1,
            this.toolStripPos2,
            this.toolStripPos3,
            this.toolStripPos4,
            this.toolStripPos5,
            this.toolStripPos6,
            this.toolStripPos7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonShip
            // 
            this.toolStripButtonShip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShip.Image")));
            this.toolStripButtonShip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShip.Name = "toolStripButtonShip";
            this.toolStripButtonShip.Size = new System.Drawing.Size(34, 22);
            this.toolStripButtonShip.Text = "Ship";
            this.toolStripButtonShip.ToolTipText = "Add a ship";
            this.toolStripButtonShip.Click += new System.EventHandler(this.toolStripButtonShip_Click);
            // 
            // toolStripButtonChest
            // 
            this.toolStripButtonChest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonChest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChest.Image")));
            this.toolStripButtonChest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChest.Name = "toolStripButtonChest";
            this.toolStripButtonChest.Size = new System.Drawing.Size(41, 22);
            this.toolStripButtonChest.Text = "Chest";
            this.toolStripButtonChest.ToolTipText = "Change forests into chests";
            this.toolStripButtonChest.Click += new System.EventHandler(this.OnChest);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "0";
            this.toolStripButton8.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos1
            // 
            this.toolStripPos1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos1.Image")));
            this.toolStripPos1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos1.Name = "toolStripPos1";
            this.toolStripPos1.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos1.Text = "1";
            this.toolStripPos1.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos2
            // 
            this.toolStripPos2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos2.Image")));
            this.toolStripPos2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos2.Name = "toolStripPos2";
            this.toolStripPos2.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos2.Text = "2";
            this.toolStripPos2.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos3
            // 
            this.toolStripPos3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos3.Image")));
            this.toolStripPos3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos3.Name = "toolStripPos3";
            this.toolStripPos3.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos3.Text = "3";
            this.toolStripPos3.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos4
            // 
            this.toolStripPos4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos4.Image")));
            this.toolStripPos4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos4.Name = "toolStripPos4";
            this.toolStripPos4.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos4.Text = "4";
            this.toolStripPos4.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos5
            // 
            this.toolStripPos5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos5.Image")));
            this.toolStripPos5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos5.Name = "toolStripPos5";
            this.toolStripPos5.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos5.Text = "5";
            this.toolStripPos5.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos6
            // 
            this.toolStripPos6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos6.Image")));
            this.toolStripPos6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos6.Name = "toolStripPos6";
            this.toolStripPos6.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos6.Text = "6";
            this.toolStripPos6.Click += new System.EventHandler(this.onSetPosition);
            // 
            // toolStripPos7
            // 
            this.toolStripPos7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPos7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPos7.Image")));
            this.toolStripPos7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPos7.Name = "toolStripPos7";
            this.toolStripPos7.Size = new System.Drawing.Size(23, 22);
            this.toolStripPos7.Text = "7";
            this.toolStripPos7.Click += new System.EventHandler(this.onSetPosition);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 833);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 802);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 666);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserControlLocationSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlLocationSelector";
            this.Size = new System.Drawing.Size(792, 833);
            this.Load += new System.EventHandler(this.UserControlLocationSelector_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShip;
        private System.Windows.Forms.ToolStripButton toolStripButtonChest;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripPos1;
        private System.Windows.Forms.ToolStripButton toolStripPos2;
        private System.Windows.Forms.ToolStripButton toolStripPos3;
        private System.Windows.Forms.ToolStripButton toolStripPos4;
        private System.Windows.Forms.ToolStripButton toolStripPos5;
        private System.Windows.Forms.ToolStripButton toolStripPos6;
        private System.Windows.Forms.ToolStripButton toolStripPos7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
