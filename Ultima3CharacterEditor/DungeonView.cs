using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ultima3CharacterEditor
{
    public partial class  DungeonView : UserControl
    {
        int level = 1;

        public DungeonView()
        {
            InitializeComponent();
//            tileSetup();
//            readDungeon();
        }

        public DungeonView(DungeonDataSource datasource, int level = 1)
        {
            InitializeComponent();
            this.datasource = datasource;
            this.level = level;
        }

        private void DungeonView_Load(object sender, EventArgs e)
        {

        }

        public DungeonDataSource datasource { get; set; }

        int marginx = 5;
        int marginy = 5;

        public void DisplayTile(Graphics g, int tileNum, int row, int col)
        {
            g.DrawImageUnscaled(datasource.getTileArray()[tileNum], col * datasource.getTileHeight() + marginx, row * datasource.getTileWidth() + marginy);
        }

        private void DungeonView_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("DungeonView_Paint()");

            if (datasource.getTileArray() == null)
                return;

            Graphics g = e.Graphics;

            if (datasource.getDungeonData() != null) 
                dungeonDraw(g, level);
            
        }

        private void dungeonDraw(Graphics g, int level)
        {
            g.DrawRectangle(Pens.Black, marginx, marginy, datasource.getTileWidth() * (datasource.getDungeonWidth()),
                                                          datasource.getTileHeight() * (datasource.getDungeonHeight()));
            for (int ii = 0; ii < datasource.getDungeonHeight(); ii++)
            {
                for (int jj = 0; jj < datasource.getDungeonWidth(); jj++)
                {
                    int tilenum = datasource.getDungeonData()[level-1][ii, jj];
                    DisplayTile(g, tilenum, ii, jj);
                }
            }
        }
        

    }
}
