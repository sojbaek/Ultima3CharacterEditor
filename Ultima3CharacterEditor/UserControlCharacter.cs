using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultima3CharacterEditor
{
    public partial class UserControlCharacter : UserControl
    {

        RadioButton[] rbArrayArmour;
        RadioButton[] rbArrayWeapon;
        NumericUpDown[] nudArrayArmour;
        NumericUpDown[] nudArrayWeapon;
        //        int currentIndex = -1;

        //      public U3Character[] roster;
        public U3Character character;
        public U3CharacterEditorControl parent;

        Ultima3Doc doc;


        public UserControlCharacter(U3Character character, Ultima3Doc doc)
        {
            this.character = character;
            this.doc = doc;
            InitializeComponent();
            InitilizeCharacter();
        }

        private void InitilizeCharacter()
        {
            
            rbArrayArmour = new RadioButton[] {this.rbSkin,
            this.rbCloth, this.rbLeather, this.rbChain, this.rbPlate, this.rb2pChain, this.rb2pPlate, this.rbExoticArmour};

            rbArrayWeapon = new RadioButton[]
            {   this.rbHands, this.rbDagger,
                this.rbMace, this.rbSling,
                this.rbAxe, this.rbBow,
                this.rbSword, this.rb2HSword,
                this.rb2pAxe, this.rb2pBow,
                this.rb2pSword, this.rbGloves,
                this.rb4pAxe, this.rb4pBow,
                this.rb4pSword, this.rbExoticWeapon};

            nudArrayArmour = new NumericUpDown[] {null,
            this.nudCloth, this.nudLeather, this.nudChain, this.nudPlate, this.nud2pChain, this.nud2pPlate, this.nudExoticArmour};

            nudArrayWeapon = new NumericUpDown[] {  null, this.nudDagger,
                this.nudMace, this.nudSling,
                this.nudAxe, this.nudBow,
                this.nudSword, this.nud2HSword,
                this.nud2pAxe, this.nud2pBow,
                this.nud2pSword, this.nudGloves,
                this.nud4pAxe, this.nud4pBow,
                this.nud4pSword, this.nudExoticWeapon};

            foreach (string s in U3Character.sexLabel.Values)
            {
                cbSex.Items.Add(s);
            }

            foreach (string s in U3Character.professionLabel.Values)
            {
                cbProfession.Items.Add(s);
            }

            foreach (string s in U3Character.raceLabel.Values)
            {
                cbRace.Items.Add(s);
            }

        }
        private void UserControlCharacter_Load(object sender, EventArgs e)
        {

        }
            
        public void UpdateControls()
        {
            //     currentIndex= index;
            if (character == null) return;
            
            tbExp.Text = character.Experience.ToString();
            tbGold.Text = character.Gold.ToString();
            tbHP.Text = character.HP.ToString();
            tbMaxHP.Text = character.MaxHP.ToString();
            tbFood.Text = character.Food.ToString();
                        nudKeys.Value = character.Keys;
            nudGems.Value = character.Gems;
            nudTorches.Value = character.Torches;
            nudPowders.Value = character.Powders;
            nudMaxMagic.Value = character.MaxMagic;
            nudMagic.Value = character.Magic;
            nudWisdom.Value = character.Wisdom;
            nudIntelligence.Value = character.Intelligence;
            nudDexterity.Value = character.Dexterity;
            nudStrength.Value = character.Strength;

            for (int i= 0; i < rbArrayArmour.Length; i++)
            {
                if ((int) character.ArmourReadied == i)
                {
                    rbArrayArmour[i].Select();
                }

                if (i != 0)
                {
                    nudArrayArmour[i].Value = character.Armour[i];
                }
            }

            for (int i = 0; i < rbArrayWeapon.Length; i++)
            {
                if ((int)character.WeaponReadied == i)
                {
                    rbArrayWeapon[i].Select();
                }

                if (i != 0)
                {
                    nudArrayWeapon[i].Value = character.Weapons[i];
                }
            }

            tbName.Text = character.Name;
            cbRace.SelectedIndex = cbRace.FindStringExact(U3Character.raceLabel[character.Race]);
            cbProfession.SelectedIndex = cbProfession.FindStringExact(U3Character.professionLabel[character.Profession]);
            cbSex.SelectedIndex = cbSex.FindStringExact(U3Character.sexLabel[character.Sex]);

            //private System.Windows.Forms.PictureBox pbIcon

            cbForce.Checked = (character.CardsMarks & (byte)Marks.FORCE) > 0;
            cbSnake.Checked = (character.CardsMarks & (byte)Marks.SNAKE) > 0;
            cbFire.Checked = (character.CardsMarks & (byte)Marks.FIRE) > 0;
            cbKings.Checked = (character.CardsMarks & (byte)Marks.KINGS) > 0;

            cbDeath.Checked = (character.CardsMarks & (byte)Cards.DEATH) > 0;
            cbMoons.Checked = (character.CardsMarks & (byte)Cards.MOONS) > 0;
            cbSol.Checked = (character.CardsMarks & (byte)Cards.SOL) > 0;
            cbLove.Checked = (character.CardsMarks & (byte)Cards.LOVE) > 0;

            string professionLabel = U3Character.professionLabel[character.Profession];
            pbIcon.Image = doc.ImageTileForProfession(professionLabel);
        }
        
        public void SaveCharacter()
        {
            if (character == null) return;

            character.Experience = Convert.ToUInt16(this.tbExp.Text);
            character.Gold = Convert.ToUInt16(tbGold.Text);
            character.HP = Convert.ToUInt16(tbHP.Text);
            character.MaxHP = Convert.ToUInt16(tbMaxHP.Text);
            character.Food = Convert.ToUInt16(tbFood.Text);

            character.Keys = (byte) this.nudKeys.Value;
            character.Gems = (byte)this.nudGems.Value;
            character.Torches = (byte) this.nudTorches.Value;
            character.Powders = (byte) this.nudPowders.Value;
            character.MaxMagic = (byte) this.nudMaxMagic.Value;
            character.Magic = (byte) this.nudMagic.Value;
            character.Wisdom = (byte) this.nudWisdom.Value;
            character.Intelligence = (byte) this.nudIntelligence.Value;
            character.Dexterity = (byte) this.nudDexterity.Value;
            character.Strength = (byte) this.nudStrength.Value;

            for (int i = 1; i < rbArrayArmour.Length; i++)
            {
                character.Armour[i] = (byte) nudArrayArmour[i].Value;
                if (rbArrayArmour[i].Checked)
                {
                    character.ArmourReadied = (ArmourType)i;
                    break;
                }
                character.ArmourReadied = 0;
            }

            for (int i = 1; i < rbArrayWeapon.Length; i++)
            {
                character.Weapons[i] = (byte)nudArrayWeapon[i].Value;
                if (rbArrayWeapon[i].Checked)
                {
                    character.WeaponReadied = (WeaponType)i;
                    break;
                }
                character.WeaponReadied = 0;
            }

            character.Name = tbName.Text;
            character.Race =  U3Character.raceArray[cbRace.SelectedIndex];
            character.Profession = U3Character.professionArray[cbProfession.SelectedIndex];
            character.Sex = U3Character.sexArray[cbSex.SelectedIndex];

            //private System.Windows.Forms.PictureBox pbIcon
            character.CardsMarks = (byte)(
                (cbForce.Checked ? (byte)Marks.FORCE : 0) +
                (cbSnake.Checked ? (byte)Marks.SNAKE : 0) +
                (cbFire.Checked ? (byte)Marks.FIRE : 0) +
                (cbKings.Checked ? (byte)Marks.KINGS : 0) +
                (cbDeath.Checked ? (byte)Cards.DEATH : 0) +
                (cbMoons.Checked ? (byte)Cards.MOONS : 0) +
                (cbSol.Checked ? (byte)Cards.SOL : 0) +
                (cbLove.Checked ? (byte)Cards.LOVE : 0)); 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (character != null)
            {
                this.UpdateControls();
            }
        }

        private void somethingChanged(object sender, EventArgs e) 
        {
            //U3Character c = roster[currentIndex];
            Console.WriteLine("somethingChanged()");
            //character.Name = tbName.Text;
            //if (cbRace.SelectedIndex >= 0)
            //    c.Race = U3Character.raceArray[cbRace.SelectedIndex];

            //if (cbProfession.SelectedIndex>=0)
            //    c.Profession = U3Character.professionArray[cbProfession.SelectedIndex];

            //if (cbSex.SelectedIndex >= 0) 
            //    c.Sex = U3Character.sexArray[cbSex.SelectedIndex];
            
            //parent.refreshTableRow(currentIndex);   // This should be changed in the future
        }

        private void onMap(object sender, EventArgs e)
        {
            Console.WriteLine("UserControlCharacter.cs:onMap()");
// Console.WriteLine("The Player Location = ({0},{1})", cb);
            UserControlLocationSelector window = new UserControlLocationSelector(parent.doc);
          //  window.ShowDialog();
        }
    }
}
