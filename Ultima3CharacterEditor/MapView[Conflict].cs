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

namespace Ultima3CharacterEditor
{
    public partial class MapView : UserControl
    {
        public Ultima3Doc doc = null;

        Image img = null;

        int xmargin = 3;
        int ymargin = 3;
        int timeDelay = 300;
        Timer timer = null;
        byte[] mapData;
        Bitmap[] animatedMap;
        float zoomLevel = 1.0F;
        RectangleF destinationRect = new RectangleF();
        RectangleF sourceRect = new RectangleF();
        bool animated = false;
        int frame = 0;

        
        static Dictionary<string, float> zoomLevelDic = new Dictionary<string, float>() {
            {"50%",0.5F },
            {"100%",1F},
            {"200%",2F},
            {"300%",3F} };

        string[] zoomLevels = (new List<string>(zoomLevelDic.Keys)).ToArray();

        const int defaultLocationIndex = 0; // Sosaria

        public MapView()
        {
            InitializeComponent();

            this.toolStripComboBoxLocation.Items.AddRange(Ultima3Doc.MapNames);
            this.toolStripComboBoxZoom.Items.AddRange(zoomLevels);
            this.toolStripComboBoxLocation.SelectedIndex = defaultLocationIndex;  // Sosaria
            this.toolStripComboBoxZoom.SelectedIndex = 1; // 100%
            zoomLevel = 1.0F;
        }

        void setZoom()
        {
            sourceRect.Width = doc.animatedMap[0].Size.Width;
            sourceRect.Height = doc.animatedMap[0].Size.Height;

            destinationRect.X = xmargin;
            destinationRect.Y = ymargin;
            destinationRect.Width = doc.animatedMap[0].Size.Width * zoomLevel ;
            destinationRect.Height = doc.animatedMap[0].Size.Height * zoomLevel;
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //            pictureBox1.Scale((SizeF)new SizeF((float)zoomLevel, (float)zoomLevel));
            pictureBox1.Size = new Size((int)destinationRect.Right, (int) destinationRect.Bottom);
            
        }

        public void loadMap(int index)
        {
            if (doc != null)
            {
                string mapFilePath = doc.u3Dir + "\\" + Ultima3Doc.MapFileNames[index];
                // Bitmap DrawMapFromData(byte[] mapData, byte[][] iconbuf, int counter = 0)

                mapData = Ultima3Doc.ReadMapFromFile(mapFilePath);
                img = doc.map;
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
                g.DrawImage(img, destinationRect, sourceRect, GraphicsUnit.Pixel);
                Console.WriteLine("Panel1 size = {0}", pictureBox1.Size);
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


        private void onAnimationCheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            animated = tsb.CheckState == CheckState.Checked;
            AnimateMap(timeDelay);
        }
    }
}


//public Image CreateAnimation(Image[] frames, int delay)
//{
//    var ms = new System.IO.MemoryStream();
//    var codec = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff");

//    EncoderParameters encoderParameters = new EncoderParameters(2);
//    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
//    encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)EncoderValue.CompressionLZW);
//    frames[0].Save(ms, codec, encoderParameters);

//    encoderParameters = new EncoderParameters(1);
//    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
//    for (int i = 1; i < frames.Length; i++)
//    {
//        frames[0].SaveAdd(frames[i], encoderParameters);
//    }
//    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
//    frames[0].SaveAdd(encoderParameters);

//    ms.Position = 0;
//    var img = Image.FromStream(ms);
//    Animate( img, delay, frames.Length);
//    return img;
//}

//private void Animate( Image img, int delay, int numFrames)
//{
//    int frame = 0;
//    var tmr = new Timer() { Interval = delay, Enabled = true };
//    tmr.Tick += delegate {
//        frame++;
//        Console.WriteLine("tick:{0}", frame);
//        if (frame >= numFrames) frame = 0;
//        img.SelectActiveFrame(FrameDimension.Page, frame);
//        this.Invalidate();
//        this.Refresh();
//    };
//    this.Disposed += delegate { tmr.Dispose(); };
//}

//pictureBox1.Image = CreateAnimation(pictureBox1,
//    new Image[] { Properties.Resources.Frame1, Properties.Resources.Frame2, Properties.Resources.Frame3
//                }, 
//    new int[] { 1000, 2000, 300 });