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
        int currentIndex = -1;
                

        public Character[] roster;
        public FormMain parent;

        public UserControlCharacter()
        {
            InitializeComponent();
        }

        private void UserControlCharacter_Load(object sender, EventArgs e)
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

            foreach (string s in Character.sexLabel.Values)
            {
                cbSex.Items.Add(s);
            }

            foreach (string s in Character.professionLabel.Values)
            {
                cbProfession.Items.Add(s);
            }

            foreach (string s in Character.raceLabel.Values)
            {
                cbRace.Items.Add(s);
            }
        }
            
        public void Update(int index)
        {
            currentIndex= index;
            Character c = roster[index];
       
            tbName.Text = c.Name;
            tbExp.Text = c.Experience.ToString();
            tbGold.Text = c.Gold.ToString();
            tbHP.Text = c.HP.ToString();
            tbMaxHP.Text = c.MaxHP.ToString();
            tbFood.Text = c.Food.ToString();

            nudKeys.Value = c.Keys;
            nudGems.Value = c.Gems;
            nudTorches.Value = c.Torches;
            nudPowders.Value = c.Powders;
            nudMaxMagic.Value = c.MaxMagic;
            nudMagic.Value = c.Magic;
            nudWisdom.Value = c.Wisdom;
            nudIntelligence.Value = c.Intelligence;
            nudDexterity.Value = c.Dexterity;
            nudStrength.Value = c.Strength;

            for (int i= 0; i < rbArrayArmour.Length; i++)
            {
                if ((int) c.ArmourReadied == i)
                {
                    rbArrayArmour[i].Select();
                }

                if (i != 0)
                {
                    nudArrayArmour[i].Value = c.Armour[i];
                }
            }

            for (int i = 0; i < rbArrayWeapon.Length; i++)
            {
                if ((int)c.WeaponReadied == i)
                {
                    rbArrayWeapon[i].Select();
                }

                if (i != 0)
                {
                    nudArrayWeapon[i].Value = c.Weapons[i];
                }
            }

            cbRace.SelectedIndex = cbRace.FindStringExact(Character.raceLabel[c.Race]);
            cbProfession.SelectedIndex = cbProfession.FindStringExact(Character.professionLabel[c.Profession]);
            cbSex.SelectedIndex = cbSex.FindStringExact(Character.sexLabel[c.Sex]);

            //private System.Windows.Forms.PictureBox pbIcon

            cbForce.Checked = (c.CardsMarks & (byte)Marks.FORCE) > 0;
            cbSnake.Checked = (c.CardsMarks & (byte)Marks.SNAKE) > 0;
            cbFire.Checked = (c.CardsMarks & (byte)Marks.FIRE) > 0;
            cbKings.Checked = (c.CardsMarks & (byte)Marks.KINGS) > 0;

            cbDeath.Checked = (c.CardsMarks & (byte)Cards.DEATH) > 0;
            cbMoons.Checked = (c.CardsMarks & (byte)Cards.MOONS) > 0;
            cbSol.Checked = (c.CardsMarks & (byte)Cards.SOL) > 0;
            cbLove.Checked = (c.CardsMarks & (byte)Cards.LOVE) > 0;
        }
        
        public void SaveCharacter(int index)
        {
            Character c = roster[index];

            c.Name = tbName.Text;
            c.Experience = Convert.ToUInt16(this.tbExp.Text);
            c.Gold = Convert.ToUInt16(tbGold.Text);
            c.HP = Convert.ToUInt16(tbHP.Text);
            c.MaxHP = Convert.ToUInt16(tbMaxHP.Text);
            c.Food = Convert.ToUInt16(tbFood.Text);

            c.Keys = (byte) this.nudKeys.Value;
            c.Gems = (byte)this.nudGems.Value;
            c.Torches = (byte) this.nudTorches.Value;
            c.Powders = (byte) this.nudPowders.Value;
            c.MaxMagic = (byte) this.nudMaxMagic.Value;
            c.Magic = (byte) this.nudMagic.Value;
            c.Wisdom = (byte) this.nudWisdom.Value;
            c.Intelligence = (byte) this.nudIntelligence.Value;
            c.Dexterity = (byte) this.nudDexterity.Value;
            c.Strength = (byte) this.nudStrength.Value;

            for (int i = 1; i < rbArrayArmour.Length; i++)
            {
                c.Armour[i] = (byte) nudArrayArmour[i].Value;
                if (rbArrayArmour[i].Checked)
                {
                    c.ArmourReadied = (ArmourType)i;
                    break;
                }
                c.ArmourReadied = 0;
            }

            for (int i = 1; i < rbArrayWeapon.Length; i++)
            {
                c.Weapons[i] = (byte)nudArrayWeapon[i].Value;
                if (rbArrayWeapon[i].Checked)
                {
                    c.WeaponReadied = (WeaponType)i;
                    break;
                }
                c.WeaponReadied = 0;
            }

            c.Race =  Character.raceArray[cbRace.SelectedIndex];
            c.Profession = Character.professionArray[cbProfession.SelectedIndex];
            c.Sex = Character.sexArray[cbSex.SelectedIndex];

            //private System.Windows.Forms.PictureBox pbIcon
            c.CardsMarks = (byte)(
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
            if (currentIndex != -1)
            {
                this.Update(currentIndex);
            }
        }

        private void somethingChanged(object sender, EventArgs e) 
        {
            parent.refreshTableRow(currentIndex);   // This should be changed in the future
        }
    }
}
