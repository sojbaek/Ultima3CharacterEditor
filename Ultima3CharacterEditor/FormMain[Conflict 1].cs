using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ultima3CharacterEditor
{
    public delegate void StatusStripChangeHandler(String newMessage);

    public partial class FormMain : Form
    {
        
        public Ultima3Doc party;

        // const string defaultPath = "C:\\Users\\baeks\\Google Drive\\VisualStudioProject\\Ultima3CharacterEditor\\R\\Ultima 3";
        const string defaultPath = "D:\\GOG Galaxy\\Games\\Ultima 3";

        private MapView mapViewControl;
        private DungeonViewControl dgViewControl;
        private U3CharacterEditorControl u3CharacterEditorControl;

        public FormMain()   
        {
            party = new Ultima3Doc(defaultPath);
            
            InitializeComponent();

            //MultiplicationTableSetup();
            AddCharacterEditControl();
            AddMapView();
            AddDungeonViewControl();
        }

        void FormMain_OnStatusStripChange(String newMessage)
        {
            Console.WriteLine("", newMessage);
            toolStripStatusLabel2.Text = newMessage;
        }

        public void AddMapView()
        {
            mapViewControl = new MapView();
            mapViewControl.doc = this.party;

            tabPageMapViewer.Controls.Add(mapViewControl);
            
            
            mapViewControl.setupMap();
            mapViewControl.OnStatusStripChange += FormMain_OnStatusStripChange;

            mapViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            mapViewControl.Location = new System.Drawing.Point(0, 0);
            mapViewControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            mapViewControl.Name = "mapView";
            mapViewControl.Size = new System.Drawing.Size(1024,1024);
        }

        public void AddDungeonViewControl()
        {
            dgViewControl = new DungeonViewControl(party);

            tabPageDungeonViewer.Controls.Add(dgViewControl);

            dgViewControl.Dock = DockStyle.Fill;
            tabPageDungeonViewer.Name = "DungeonViewControl";
        }

        public void AddCharacterEditControl()
        {
            u3CharacterEditorControl = new U3CharacterEditorControl(party);
            tabPageCharacterControl.Controls.Add(u3CharacterEditorControl);
            u3CharacterEditorControl.Dock = DockStyle.Fill;
        }
        

        private void FormMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("FormMain.cs:FormMain_Load()");
            

        }


        private void onMap(object sender, EventArgs e)
        {
            
            Console.WriteLine("FormMain.cs:onMap()");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("FormMain.cs:saveToolStripMenuItem_Click()");
            Console.WriteLine("Saving...");
            //for (int ii=0; ii < party.numCharacter(); ii++)
            //    ucCharacters[ii].SaveCharacter();
            party.Save();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
