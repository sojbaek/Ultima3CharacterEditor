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
    public partial class UserControlLocationSelector : UserControl
    {
        private Ultima3Doc doc;
        int[,] predefinedLocation = new int[,]
        {                   
            {8,8 },    //0  | North of Moon, past a mountain range
            {57,46},   //1  | Island south of Death Gulch by Snake Dungeon
            {15,27 },  //2  | Hidden corridor, north square
            {36,58 },  //3  | Sosaria's southern shore, west of the Montors
            {15,29 },  //4  | Hidden corridor, south square
            {12,55 },  //5  | On the isle of Exodus, but you can only look not touch!
            {11,13},   //6  | Easternmost part of Devil Guard area(inside mountain)
            {58,31 },  //7  | Enclosed area, Time to the north           
            {45,19 }   //8  | Home location
        };

        
        public UserControlLocationSelector(Ultima3Doc u3doc)
        {
            InitializeComponent();
            this.doc = u3doc;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void onSetPosition(object sender, EventArgs e)
        {
            //    Button clickedButton = sender as Button;
            //   
            ToolStripButton clickedButton = sender as ToolStripButton;
            if (clickedButton == null) return;
            int posNum = Int32.Parse(clickedButton.Text.ToString());
            if (posNum >= 0 && posNum < predefinedLocation.Length)
            {
                doc.setPlayerLocation(predefinedLocation[posNum, 0],
                    predefinedLocation[posNum, 1]);
                Console.WriteLine("Player pos is set to {0},{1}", predefinedLocation[posNum, 0],
                    predefinedLocation[posNum, 1]);
            }
        }

        private void OnChest(object sender, EventArgs e)
        {
            doc.changeForestIntoChests();
        }

        private void toolStripButtonShip_Click(object sender, EventArgs e)
        {
            doc.placeShips();
        }

        private void UserControlLocationSelector_Load(object sender, EventArgs e)
        {         
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }
    }
}
