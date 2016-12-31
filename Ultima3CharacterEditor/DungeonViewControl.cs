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

    public interface DungeonDataSource
    {
        int[][,] getDungeonData();
        Bitmap[] getTileArray();
        int getTileWidth();
        int getTileHeight();

        int getDungeonWidth();
        int getDungeonHeight();
        int getDungeonLevels();
    }

    public partial class DungeonViewControl : UserControl, DungeonDataSource
    {
        public DungeonViewControl()
        {
            InitializeComponent();
            tileSetup();
            populateLegend();
        }

        public DungeonViewControl(Ultima3Doc doc)
        {
            this.doc = doc;
            InitializeComponent();
            controlSetup();
            tileSetup();
            populateLevelTabPages();
            populateLegend();
            updateDungeon();
        }


        Bitmap dungeonTile;
        Bitmap[] tileArray;
        int[][,] dungeonData = null;
        DungeonView[] dungeonViews;
        TabPage[] dungeonViewTabPages;
        ImageList imageListLegend = null;
        Ultima3Doc doc = null;

        const string dungeonTileFileName = "../../DungeonTiles.tiff";

        public static Dictionary<string, string> dungeonFileDic = new Dictionary<string, string>() {
            {"Doom","M.ULT"},
            {"Fires of Hell","FIRE.ULT" },
            {"Time Awaits","TIME.ULT"},
            {"Clues","P.ULT"},
            {"Perinian Depths","PERINIAN.ULT"},
            {"Mines of Morinia","MINE.ULT"},
            {"Dardin's Pit","DARDIN.ULT"}
        };

        public static Dictionary<int, int> tileDic = new Dictionary<int, int>() {
            {0,0},
            { 1,1},  // time lord
            {2,2 },  // fountain
            {3,3 }, // strange wind
            {4,4 }, // trap
            {5,5 }, // mark
            {6,6 }, // gremlin
            {8,7 }, // message
            {16,8}, // up ladder
            {32,9 }, // down ladder
            {48, 14},// up& down ladder
            {64, 15 }, // chest
            {128, 16 }, // wall
            {160, 17 }, // hidden passage
            {192, 18 } // door
        };

        public static Dictionary<int, string> tileName = new Dictionary<int, string>() {
            {0,"ground"},
            {1,"Time Lord"},  // time lord
            {2,"fountain"},  // fountain
            {3,"strange Wind"}, // strange wind
            {4,"trap"}, // trap
            {5,"mark"}, // mark
            {6,"gremlin" }, // gremlin
            {7,"message" }, // message
            {8, "up ladder"}, // up ladder
            {9, "down ladder" }, // down ladder
            {14,"up & down ladder"},// up& down ladder
            {15,"chest" }, // chest
            {16,"wall" }, // wall
            {17,"hidden passage" }, // hidden passage
            {18,"doorway" } // door
        };

        const int dungeonTileRowNum = 2;
        const int dungeonTileColNum = 10;

        public int tileWidth = 32;
        public int tileHeight = 32;

        public const int dungeonWidth = 16;
        public const int dungeonHeight = 16;
        public const int dungeonLevels = 8;

        //public void SetDocument(Ultima3Doc doc)
        //{
        //    this.doc = doc;
        //    updateDungeon();
        //}

        public void controlSetup()
        {
            this.toolStripComboBox1.Items.AddRange(dungeonFileDic.Keys.ToArray());
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        public void populateLevelTabPages()
        {
            dungeonViewTabPages = new TabPage[dungeonLevels];
            dungeonViews = new DungeonView[dungeonLevels];
            for (int ii = 0; ii < dungeonLevels; ii++)
            {

                dungeonViewTabPages[ii] = new System.Windows.Forms.TabPage();

                this.tabControlDungeonLevel.Controls.Add(dungeonViewTabPages[ii]);

                dungeonViewTabPages[ii].Location = new System.Drawing.Point(4, 22);
                dungeonViewTabPages[ii].Padding = new System.Windows.Forms.Padding(3);
                dungeonViewTabPages[ii].Size = new System.Drawing.Size(498, 596);
                dungeonViewTabPages[ii].TabIndex = 4;
                dungeonViewTabPages[ii].UseVisualStyleBackColor = true;

                dungeonViews[ii] = new DungeonView(this, ii + 1);

                dungeonViewTabPages[ii].Controls.Add(dungeonViews[ii]);
                dungeonViews[ii].Dock = DockStyle.Fill;
                dungeonViewTabPages[ii].Text = string.Format("Level {0} 레벨 {0}", ii + 1);
            }
        }

        public void populateLegend()
        {
            // create image list and fill it 
            var tileKeys = tileName.Keys.ToArray();

            imageListLegend = new ImageList();
            foreach (int tilekey in tileKeys)
            {
                var legend = tileName[tilekey];
                imageListLegend.Images.Add(tileName[tilekey], tileArray[tilekey]);
                var lvitem = listView1.Items.Add(legend);
                lvitem.ImageKey = legend;
            }
            imageListLegend.ImageSize = new Size(32, 32);
            imageListLegend.ColorDepth = ColorDepth.Depth32Bit;
            // tell your ListView to use the new image list
            listView1.LargeImageList = imageListLegend;
        }

        public void updateDungeon()
        {
            var DGSelected = toolStripComboBox1.SelectedItem;
            var dungeonFile = doc.u3Dir + "\\" + dungeonFileDic[(string)DGSelected];
            readDungeon(dungeonFile);

        }

        public Bitmap copySubimage(int rowNum, int colNum)
        {
            //Rectangle r = new Rectangle(colNum * tileWidth ,rowNum * tileHeight, tileWidth, tileHeight);
            Bitmap target = new Bitmap(tileWidth, tileHeight);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(dungeonTile, -colNum * tileWidth, -rowNum * tileHeight);
            }
            return target;

        }

        public void tileSetup()
        {
            dungeonTile = new Bitmap(dungeonTileFileName);
            tileArray = new Bitmap[dungeonTileColNum * dungeonTileRowNum];
            for (int ii = 0; ii < dungeonTileRowNum; ii++)
            {
                for (int jj = 0; jj < dungeonTileColNum; jj++)
                {
                    tileArray[ii * dungeonTileColNum + jj] = copySubimage(ii, jj);
                }
            }
        }

        private void readDungeon(string dungeonFile)
        {
            dungeonData = DungeonViewControl.ReadDungeonFromFile(dungeonFile);
        }

        public static int[][,] ReadDungeonFromFile(string dungeonFilename)
        {
            int[][,] dungeonData;
            Byte[] buff;

            int dungeonsize = dungeonWidth * dungeonHeight * dungeonLevels;

            if (!File.Exists(dungeonFilename))
            {
                System.Windows.Forms.MessageBox.Show(String.Format("{0} not found", dungeonFilename), "Error: File Not Found");
                return null;
            }

            dungeonData = new int[dungeonLevels][,];
            buff = new Byte[dungeonsize];

            using (BinaryReader reader = new BinaryReader(File.Open(dungeonFilename, FileMode.Open)))
            {
                buff = reader.ReadBytes(dungeonsize);
                int ll = 0;
                for (int kk = 0; kk < dungeonLevels; kk++)
                {
                    dungeonData[kk] = new int[dungeonHeight, dungeonWidth];
                    for (int ii = 0; ii < dungeonHeight; ii++)
                    {
                        for (int jj = 0; jj < dungeonWidth; jj++)
                        {
                            dungeonData[kk][ii, jj] = tileDic[(int)buff[ll]];
                            ll++;
                        }
                    }
                }
            }
            return dungeonData;
        }

        public int[][,] getDungeonData()
        {
            return dungeonData;
        }

        public Bitmap[] getTileArray()
        {
            return tileArray;
        }

        public int getTileWidth()
        {
            return tileWidth;
        }

        public int getTileHeight()
        {
            return tileHeight;
        }

        public int getDungeonWidth()
        {
            return dungeonWidth;
        }

        int DungeonDataSource.getDungeonHeight()
        {
            return dungeonHeight;
        }

        int DungeonDataSource.getDungeonLevels()
        {
            return dungeonLevels;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDungeon();
            this.Invalidate();
        }
    }
}
