using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ultima3CharacterEditor
{
    public partial class MapView : UserControl
    {
        public Ultima3Doc doc = null;

        Image img = null;

        const int xmarginleft = 3;
        const int ymargintop = 3;
        const int xmarginright = 100;
        const int ymarginbottom = 30;

        int timeDelay = 300;
        Timer timer = null;
        byte[] mapData;
        Bitmap[] animatedMap;
        Ultima3NPC[] npcs;

        float zoomLevel = 1.0F;
        RectangleF destinationRect = new RectangleF();
        RectangleF sourceRect = new RectangleF();
        bool animated = false;
        bool isMainMap = false;
        bool isLabelsEnabled = false;

        int NumFrames;

        int frame = 0;
        
        Bitmap partyIcon;
        Rectangle partyRect;
        Pen redPen = null;
        Font labelFont = new Font("Arial", 11, FontStyle.Bold);
        Brush labelBrush1, labelBrush2;

        
        ToolTip ttip = new ToolTip();
        int prevMouseX = 0;
        int prevMouseY = 0;
        const int toolTipDuration = 2000;

        private event StatusStripChangeHandler _onStatusStripChange;
        public event StatusStripChangeHandler OnStatusStripChange
        {
            add
            {
                _onStatusStripChange += value;
            }
            remove
            {
                _onStatusStripChange -= value;
            }
        }

        string[] MapNames = new string[] {
            "Sosaria",
            "Ambrosia",
            "British",
            "Dawn",
            "Death",
            "Devil",
            "Exodus",
            "Fawn",
            "Grey",
            "LCB",
            "E Montor",
            "W Montor",
            "Moon",
            "Yew"};

        string[] MapFileNames = new string[] {
            "SOSARIA.ULT",
            "AMBROSIA.ULT",
            "BRITISH.ULT",
            "DAWN.ULT",
            "DEATH.ULT",
            "DEVIL.ULT",
            "EXODUS.ULT",
            "FAWN.ULT",
            "GREY.ULT",
            "LCB.ULT",
            "MONTOR_E.ULT",
            "MONTOR_W.ULT",
            "MOON.ULT",
            "YEW.ULT"};

        static Dictionary<string, float> zoomLevelDic = new Dictionary<string, float>() {
            {"50%",0.5F },
            {"100%",1F},
            {"200%",2F},
            {"300%",3F} };

        struct Annotation
        {
            public int h;
            public int v;
            public string desc;
            public string category;
            public int texth;
            public int textv;
            public Annotation(int h, int v, string desc,string category)
            {
                this.h = h; this.v = v; this.desc = desc;this.category = category;
                this.texth = h; this.textv = 0;
            }
        }
                
        
        List<Annotation> sosaria_annotation = new List<Annotation> {
            new Annotation(9,9,"0","timegate"),
            new Annotation(58,47,"1","timegate"),
            new Annotation(16,28,"2","timegate"),
            new Annotation(37,59,"3","timegate"),
            new Annotation(16,30,"4","timegate"),
            new Annotation(13,56,"5","timegate"),
            new Annotation(32,32,"6","timegate"),
            new Annotation(59,32,"7","timegate"),
            new Annotation(31,3,"Fawn","dungeon"),
            new Annotation(47,8,"Dardin's Pit","dungeon"),
            new Annotation(57,7,"Perinian Depths","dungeon"),
            new Annotation(7,14,"Moon","town"),
            new Annotation(35,17,"Yew","town"),
            new Annotation(46,19,"Lord British's Castle","castle"),
            new Annotation(47,20,"Lord British's Town","town"),
            new Annotation(10,29,"Mines of Morinia","dungeon"),
            new Annotation(19,32,"Devil Guard","town"),
            new Annotation(50,35,"Fires of Hell","dungeon"),
            new Annotation(57,32,"Death Gulch","town"),
            new Annotation(59,31,"Time Awaits","dungeon"),
            new Annotation(8,45,"Grey","town"),
            new Annotation(59,45,"Clues","dungeon"),
            new Annotation(38,54,"Dawn","town"),
            new Annotation(11,54,"Exodus Castle","castle"),
            new Annotation(48,59,"Montor West","town"),
            new Annotation(50,59,"Montor East","town"),
            new Annotation(20,58,"Doom","town")
        };


        public class U3NPCShort
        {
            public U3NPCShort(string shape, string location, string dialog, string type)
            {
                Shape = shape;
                Location = location;
                Dialog = dialog;
                Type = type;
            }

            public String Shape { get; set; }
            public String Location { get; set; }
            public String Dialog { get; set; }
            public String Type { get; set; }
        }
        int NextZero(int position) {
            while (mapData[position]!=0) {
                position = position+ 1;
            }
            return  position;
        }
        
        char[] copyBytesToChars(byte[] dat, int st, int ed)
        {
            char[] buff = new char[ed - st + 1];
            for (int ll = 0; ll <= ed - st; ll++)
            {
                buff[ll] = (char) mapData[st + ll];
           //     Console.WriteLine("buff={0}   mapData={1}", buff[ll], mapData[st + ll]);
            }
            return buff;
        }

        int[] copyBytesToInts(byte[] dat, int st, int ed)
        {
            int[] buff = new int[ed - st + 1];
            for (int ll = 0; ll <= ed - st; ll++)
            {
                buff[ll] = (int)mapData[st + ll];
                //     Console.WriteLine("buff={0}   mapData={1}", buff[ll], mapData[st + ll]);
            }
            return buff;
        }

        string[] readDialog() {
            int DIALOGSTART = 4096;
            int MAXDIALOG = 8;
            int headerlength = mapData[DIALOGSTART];
            int st, ed;
            List<string> dialogs = new List<string>();
            for (int k = DIALOGSTART; k< DIALOGSTART+headerlength; k++)
            {
                if (mapData[k] != 0)
                {
                    st = mapData[k] + DIALOGSTART;
                    ed = NextZero(st);
                    if (st < ed)
                    {
                        char[] buff = copyBytesToChars(mapData, st, ed-1);
                        string dialog = new string(buff);
                        dialogs.Add(dialog);
                    }
                }
            }
            return dialogs.ToArray();
        }

        public class Ultima3NPC
        {
            public int shape;
            public int terrain;
            public int x { get; set; }
            public int y { get; set; }
            public int dialogN;
            public int type;
            public string[] dialogs;

            public string Shape { get
                {
                    return Ultima3Doc.tileName[shape];
                }
            }
            public string Terrain
            {
                get
                {
                    return Ultima3Doc.tileName[shape];
                }
            }

            public string Location { get
                {
                    return $"({x},{y})";
                }
            }

            public string Dialog { get; set; }
            public string Type
            {
                get
                {
                    string s=string.Empty;
                    if (type == 0)
                    {
                        return "S";
                    }
                    s += ((type & 4) != 0) ? "R" : "";  // Roaming
                    s += ((type & 8) != 0) ? "F" : "";  // Following
                    return s;
                }
            }
        }

        Ultima3NPC[] readNPC (){
            int[] npcshape;
            int[] npcterrain;
            int[] npcx;
            int[] npcy;
            int[] npcdialog;
            int[] npctype;
            string[] dialogs;

            dialogs = readDialog();

            int DIALOGSTART = 4096;
            npcshape = copyBytesToInts(mapData, DIALOGSTART + 385, DIALOGSTART + 416); //  %/% 4;
            npcterrain = copyBytesToInts(mapData, DIALOGSTART + 417, DIALOGSTART + 448); //  dat[417:448] //   %/% 4;
            npcx = copyBytesToInts(mapData, DIALOGSTART + 449, DIALOGSTART + 480); // dat[449:480];
            npcy = copyBytesToInts(mapData, DIALOGSTART + 481, DIALOGSTART + 512); //  dat[481:512];
            npcdialog = copyBytesToInts(mapData, DIALOGSTART + 513, DIALOGSTART + 544); //as.numeric(dat[513:544]) %% 16;
            npctype = copyBytesToInts(mapData, DIALOGSTART + 513, DIALOGSTART + 544);//  %/% 32;  # 0=stationary, 1=?, 2=?, 4=roaming, 8=following
            
            List<Ultima3NPC> npcList = new List<Ultima3NPC>();
            for (int ii= 0; ii<31; ii++)
            {
                if (npcshape[ii] != 0)
                {
                    Ultima3NPC tempNPC = new Ultima3NPC();
                    tempNPC.shape = npcshape[ii] / 4;
                    tempNPC.terrain = npcterrain[ii] / 4;
                    tempNPC.x = npcx[ii]+1; tempNPC.y = npcy[ii]+1;
                    tempNPC.dialogN = npcdialog[ii] % 16;
                    tempNPC.Dialog = (dialogs.Length > 0 && tempNPC.dialogN > 0) ? dialogs[tempNPC.dialogN-1] : string.Empty;
                    tempNPC.Dialog = Regex.Replace(tempNPC.Dialog, @"\n", " ");
                    tempNPC.Dialog = Regex.Replace(tempNPC.Dialog, @"^\s+", "");
                    tempNPC.Dialog = Regex.Replace(tempNPC.Dialog, @"\s+$", "");
                    
                    if (tempNPC.Dialog != string.Empty)
                        annotation.Add(new Annotation(tempNPC.x, tempNPC.y, tempNPC.Dialog, tempNPC.Shape));

                    tempNPC.type = npcdialog[ii] >> 4;  //  # 0=stationary, 1=?, 2=?, 8=roaming, 16=following
                    npcList.Add(tempNPC);
                }
            }
            return npcList.ToArray();
        }

        //Dictionary<string, string> sosaria_label_dic;
        //Dictionary<string, string> sosaria_label_dic_category;

        string[] zoomLevels = (new List<string>(zoomLevelDic.Keys)).ToArray();

        const int defaultLocationIndex = 0; // Sosaria

        List<Annotation> annotation = null;
        Dictionary<string, string> label_dic = null;
        Dictionary<string, string> label_dic_category = null;

        public MapView()
        {
            InitializeComponent();
            MapViewSetup();
        }

        public MapView(Ultima3Doc doc)
        {
            this.doc = doc;

            InitializeComponent();

            MapViewSetup();
        }
    
        void GenLabelDicFromAnnotation()
        {
            bool[,] occupied = new bool[Ultima3Doc.mapwidth+5, Ultima3Doc.mapheight + 5];
            label_dic = new Dictionary<string, string>();
            label_dic_category = new Dictionary<string, string>();

            for (int kk = 0; kk < annotation.Count; kk++)
            {
                Annotation ann = annotation[kk];
                occupied[ann.h, ann.v] = true;
            }

            for (int kk = 0; kk < annotation.Count; kk++)
            {
                Annotation ann = annotation[kk];
                string key = string.Format("{0},{1}", ann.h, ann.v);
                label_dic[key] = ann.desc;
                label_dic_category[key] = ann.category;

                if (ann.category == "timegate")
                {
                    ann.textv = ann.v;
                    ann.texth = ann.h;
                } else
                {
                    bool isSuccess = true;
                    int textlength = (int)((double)ann.desc.Length * 0.7);
                    for (int jj = 0; jj < 3; jj++)
                    {
                        for (int ii = ann.h; ii < ann.h + 7; ii++)
                        {
                            if (occupied[ii, ann.v + jj])
                            {
                                isSuccess = false;
                                break;
                            }
                        }
                        if (isSuccess == true)
                        {
                            for (int ii = ann.h; ii < ann.h + 7; ii++)
                                occupied[ii, ann.v + jj] = true;
                            ann.textv = ann.v + jj;
                            break;
                        }
                        isSuccess = true;
                    }
                }
                annotation[kk] = ann;
            }

        }

        void MapViewSetup()
        {
            this.toolStripComboBoxLocation.Items.AddRange(MapNames);
            this.toolStripComboBoxZoom.Items.AddRange(zoomLevels);
            this.toolStripComboBoxLocation.SelectedIndex = defaultLocationIndex;  // Sosaria
            this.toolStripComboBoxZoom.SelectedIndex = 1; // 100%

            this.redPen = new Pen(Brushes.Red);
            this.redPen.Width = 2;

            labelBrush1 = new SolidBrush(Color.Green);
            labelBrush2 = new SolidBrush(Color.Yellow);
            
            this.ttip.ShowAlways = true;
            this.ttip.InitialDelay = 1000; // 1000 ms
            
            zoomLevel = 1.0F;
            
        }

        void refreshDoc()
        {
            if (doc != null)
            {
                float gridh = (zoomLevel * Ultima3Doc.tilewidth);
                float gridv = (zoomLevel * Ultima3Doc.tileheight);
                partyIcon = doc.Shapes[doc.status];
                partyRect = new Rectangle(xmarginleft + (int) (gridh * doc.posX),
                                          ymargintop + (int) (gridv * doc.posY),
                                          (int) gridh, 
                                          (int) gridv);
            }
        }

        void setZoom()
        {
            sourceRect.Width = doc.animatedMap[0].Size.Width;
            sourceRect.Height = doc.animatedMap[0].Size.Height;

            destinationRect.X = xmarginleft;
            destinationRect.Y = ymargintop;
            destinationRect.Width = doc.animatedMap[0].Size.Width * zoomLevel + xmarginright;
            destinationRect.Height = doc.animatedMap[0].Size.Height * zoomLevel + ymarginbottom;
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //            pictureBox1.Scale((SizeF)new SizeF((float)zoomLevel, (float)zoomLevel));
            pictureBox1.Size = new Size((int)destinationRect.Right, (int) destinationRect.Bottom);
            refreshDoc();
        }


        public void loadMap(int index)
        {
            if (doc != null)
            {
                isMainMap = MapFileNames[index] == "SOSARIA.ULT";
                
                if (isMainMap)
                {
                    // label_annotation = sosaria_annotation;
                    annotation = sosaria_annotation;
                }
                else
                {
                    annotation = new List<Annotation>();
                }
                                
                string mapFilePath = doc.u3Dir + "\\" + MapFileNames[index];
                // Bitmap DrawMapFromData(byte[] mapData, byte[][] iconbuf, int counter = 0)

                mapData = Ultima3Doc.ReadMapFromFile(mapFilePath);
                npcs = readNPC();
                img = doc.map;
                

                var npclist = from Ultima3NPC c in npcs 
                                select new U3NPCShort(c.Shape,c.Location, c.Dialog, c.Type );
                
                dataGridView1.AutoGenerateColumns = false;
//                var bindingList = new BindingList<U3NPCShort>(npclist);
 //               var source = new BindingSource(bindingList, null);
 //               dataGridView1.DataSource = source;
 
                BindingSource source = new BindingSource();
                source.DataSource = npclist;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[0].DataPropertyName = "Shape";
                dataGridView1.Columns[1].DataPropertyName = "Location";
                dataGridView1.Columns[2].DataPropertyName = "Dialog";
                dataGridView1.Columns[3].DataPropertyName = "Type";

                GenLabelDicFromAnnotation();
                animatedMap = Ultima3Doc.SetupMapAnimationFromData(mapData, doc.iconbuf, 16);
                AnimateMap(timeDelay);
            }
        }

        public void setupMap()
        {
            if (timer == null)
            {
                
                loadMap(defaultLocationIndex);
                AnimateMap(timeDelay);
                
                Console.WriteLine("Panel1 size = {0}", pictureBox1.Size);
                Console.WriteLine("mapView size = {0}", this.Size);
                //  this.Size = panel1.Size;
            }
        }


        
        
        private void onPaintPictureBox(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            if (doc != null)
            {
                if (img == null)
                {
                    setupMap();
                }
                Graphics g = e.Graphics;
                // g.DrawImage(img, destinationRect, sourceRect, GraphicsUnit.Pixel);
                g.DrawImage(img, sourceRect, sourceRect, GraphicsUnit.Pixel);
                if (isMainMap)
                {
                    if (frame % 4 > 0 || !animated)
                    {
                        g.DrawImage(partyIcon, partyRect);
                        g.DrawRectangle(redPen, partyRect);
                    }
                }
                if (isLabelsEnabled)
                {
                    foreach (Annotation ann in annotation)
                    {
                        float x1, y1, x0, y0;
                        if (ann.category == "timegate")
                        {
                            x1 = (float)(xmarginleft + (ann.texth - 1) * zoomLevel * Ultima3Doc.tilewidth);
                        }
                        else
                        {
                            x1 = (float)(xmarginleft + (ann.texth) * zoomLevel * Ultima3Doc.tilewidth);
                        }
                        
                        y1 = (float)(ymargintop + (ann.textv-1) * zoomLevel * Ultima3Doc.tileheight);
                        x0 = (float)(xmarginleft +(ann.h-0.5) * zoomLevel * Ultima3Doc.tilewidth);
                        y0 = (float)(ymargintop + (ann.v-0.5) * zoomLevel * Ultima3Doc.tileheight);
                        g.DrawString(ann.desc, labelFont, labelBrush1, x1 + 2, y1 + 2);
                        g.DrawString(ann.desc, labelFont, labelBrush2, x1, y1);
                        if (ann.category != "timegate")
                            g.DrawLine(Pens.Yellow, x0, y0, x1, y1);
                    }
                }
//                Console.WriteLine("Panel1 size = {0}", pictureBox1.Size);
            }
        }

 
        private void AnimateMap(int delay)
        {
            

            setZoom();
            
            int numFrames = animatedMap.Length;
            if (animated)
            {
                if (timer == null)
                {
                    timer = new Timer() { Interval = delay, Enabled = true };
                    timer.Tick += delegate {
                        frame++;
                        Console.WriteLine("tick:{0}", frame);
                        if (frame >= numFrames) frame = 0;
                        img = animatedMap[frame];
                        pictureBox1.Invalidate();
                        pictureBox1.Refresh();
                    };
                    this.Disposed += delegate { timer.Dispose(); };
                }
                else
                {
                    timer.Start();
                }
            } else {
                img = animatedMap[frame];
                if (timer != null)
                    timer.Stop();
                pictureBox1.Invalidate();
                pictureBox1.Refresh();
            }
        }
        
        private void onEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MapView.OnEnter()");
        }

        private void onLeave(object sender, EventArgs e)
        {
            Console.WriteLine("MapView.OnLeave()");
        }

        private void onMapSelectedIndexChanged(object sender, EventArgs e)
        {
            loadMap(((ToolStripComboBox)sender).SelectedIndex);
        }

        private void onZoomSelectedIndexChanged(object sender, EventArgs e)
        {
            if (doc != null)
            {
                ToolStripComboBox tscb = (ToolStripComboBox)sender;
                zoomLevel = zoomLevelDic[(string)tscb.SelectedItem];
                setZoom();
            }            
        }

        private string queryMapTile(int posX, int posY)
        {
            int h = (int) ((((float) posX - xmarginleft) / zoomLevel) / (float) Ultima3Doc.tilewidth) + 1;
            int v = (int) ((((float)posY -ymargintop) / zoomLevel) / (float)Ultima3Doc.tileheight) + 1;
            byte tile = Ultima3Doc.getMapTileFromData(mapData, h, v);
            return Ultima3Doc.tileName[(int)tile];
        }

        private string getAnnotation(int h, int v)
        {            
            //byte tile = Ultima3Doc.getMapTileFromData(mapData, h, v);
            if (label_dic != null)
            {

                string category="";
                
                string key = string.Format("{0},{1}", h, v);
                if (!label_dic.ContainsKey(key))
                {
                    return null;
                }
                if (label_dic_category.ContainsKey(key))
                {
                    category = "[" + label_dic_category[key] + "]";
                    if (category == "dialog")
                        category = "";
                }
                return $"{label_dic[key]} {category}";
            }
            return null;
        }

        const int toolTipMarginX = 10;
        const int toolTipMarginY = 10;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int screenX, screenY;
            int h, v;
            if (e.X != prevMouseX || e.Y != prevMouseY)
            {
                
                
                Point controlLoc = panel1.PointToScreen(pictureBox1.Location);
                Point FormLoc = this.PointToScreen(this.Location);

                screenX = e.X + controlLoc.X - FormLoc.X + xmarginleft + toolTipMarginX;
                screenY = e.Y + controlLoc.Y - FormLoc.Y + ymargintop + toolTipMarginY;
                h = (int)((((float)e.X - xmarginleft) / zoomLevel) / (float)Ultima3Doc.tilewidth) + 1;
                v = (int)((((float)e.Y - ymargintop) / zoomLevel) / (float)Ultima3Doc.tileheight) + 1;
                string mouseLoc = string.Format("({0},{1})", h, v);
                //Console.WriteLine("MouseMove :" + mouseLoc);
                String annotation = getAnnotation(h, v);
                if (annotation != null) 
                    ttip.Show(annotation, this, screenX, screenY, toolTipDuration);
                _onStatusStripChange(mouseLoc);

                prevMouseX = e.X;
                prevMouseY = e.Y;
            }
        }
                
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ttip.Hide(this);
        }

        private void onAnimationCheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            animated = tsb.CheckState == CheckState.Checked;
            AnimateMap(timeDelay);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        private void toolStripButtonLabels_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            isLabelsEnabled = tsb.CheckState == CheckState.Checked;
            pictureBox1.Invalidate();
        }
    }
}

