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
    public partial class U3CharacterEditorControl : UserControl
    {
        public U3CharacterEditorControl()
        {
            InitializeComponent();
            this.doc = null;
            setupTable();
            InitializeComponent();
            FillTabs();
        }


        public U3CharacterEditorControl(Ultima3Doc doc)
        {
            this.doc = doc;
            InitializeComponent();
            setupTable();
            FillTabs();
            RefreshPartyInfo();
        }

        int currentCharacterIndex = 0;
        String[][] characterTable;
        public Ultima3Doc doc;
        private System.Windows.Forms.TabPage[] tabPages;
        private UserControlCharacter[] ucCharacters;
        
        private void setupTable()
        {
            characterTable = new String[doc.numCharacter()][];
            for (int i = 0; i < doc.numCharacter(); i++)
            {
                characterTable[i] = new String[dgvRoster.ColumnCount];
            }
        }
        private UserControlCharacter createUCCharacters(int ii)
        {
            UserControlCharacter ucCharacter = new UserControlCharacter(doc.Player[ii], doc);
            ucCharacter.Dock = DockStyle.Fill;
            ucCharacter.Location = new System.Drawing.Point(0, 0);
            ucCharacter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            ucCharacter.Name = "ucCharacter";
            ucCharacter.parent = this;
            return ucCharacter;
        }

        private TabPage createTabPages(int ii)
        {
            TabPage tabPage = new TabPage();
            tabPage.Controls.Add(this.ucCharacters[ii]);
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = String.Format("tabPagePlayer{0}", ii + 1);
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(635, 541);
            tabPage.TabIndex = ii;
            tabPage.Text = doc.Player[ii].Name;
            tabPage.UseVisualStyleBackColor = true;
           
            return tabPage;
        }

        public void FillTabs()
        {
            int numPlayer = doc.numCharacter();
            if (numPlayer > 0)
            {
                ucCharacters = new UserControlCharacter[numPlayer];
                tabPages = new System.Windows.Forms.TabPage[numPlayer];
                for (int ii = 0; ii < numPlayer; ii++)
                {
                    Console.WriteLine("Player {0}:", ii);
                    ucCharacters[ii] = createUCCharacters(ii);
                    tabPages[ii] = createTabPages(ii);
                    this.tabControlCharacterEditor.Controls.Add(tabPages[ii]);
      
                }
            }
        }

        public void RefreshTableRow(int i)
        {
            Console.WriteLine("FormMain.cs:refreshTableRow()");
            if (doc.Player[i] != null)
            {
                characterTable[i][0] = doc.Player[i].Name;
                characterTable[i][1] = ((char)doc.Player[i].Sex).ToString();
                characterTable[i][2] = ((char)doc.Player[i].Race).ToString();
                characterTable[i][3] = ((char)doc.Player[i].Profession).ToString();

                dgvRoster.Rows[i].SetValues(characterTable[i]);
            }
        }

        public void RefreshPartyInfo()
        {
            if (doc != null)
            {
                textBoxPosX.Text = string.Format("{0}", doc.posX);                ;
                textBoxPosY.Text = string.Format("{0}", doc.posY);
                textBoxSteps.Text = string.Format("{0}", doc.steps);
                switch (doc.status)
                {
                    case (byte)Ultima3Doc.tileType.RANGER:
                        radioButtonOnFoot.Checked = true;
                        break;
                    case (byte)Ultima3Doc.tileType.FRIGATE:
                        radioButtonFrigate.Checked = true;
                        break;
                    case (byte)Ultima3Doc.tileType.HORSE:
                        radioButtonHorse.Checked = true;
                        break;
                }
                

            }
        }


        private void U3CharacterEditorControl_Load(object sender, EventArgs e)
        {
            Console.WriteLine("U3CharacterEditorControl.cs:FormMain_Load()");

            dgvRoster.Rows.Add(doc.numCharacter());
            for (int i = 0; i < doc.numCharacter(); i++)
            {
                RefreshTableRow(i);
                dgvRoster.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                ucCharacters[i].UpdateControls();
            }
        }

        private void dgvRoster_RowSelected(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("FormMain.cs:dgvRoster_CellContentClick()");
            if (e.RowIndex != currentCharacterIndex)
            {
                ucCharacters[currentCharacterIndex].SaveCharacter();
                RefreshTableRow(currentCharacterIndex);
                if (e.RowIndex >= 0 && e.RowIndex < 20)
                {
                    currentCharacterIndex = e.RowIndex;
                    ucCharacters[currentCharacterIndex].UpdateControls();

                    this.tabControlCharacterEditor.SelectedIndex = e.RowIndex;
                }
            }
        }

        private void OnPartyValueChangedX(object sender, EventArgs e)
        {
            Console.WriteLine("U3CharacerEditorControl.cs: OnPartyValueChangedX()");
            if (doc != null)
            {
                byte x;
                try
                {
                    x = byte.Parse(textBoxPosX.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Invalid Number");
                    textBoxPosX.Text = string.Format("{0}", doc.posX);
                    return;
                }
                doc.posX = x;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }

        private void OnPartyValueChangedY(object sender, EventArgs e)
        {
            Console.WriteLine("U3CharacerEditorControl.cs: OnPartyValueChangedY()");
            if (doc != null)
            {
                byte y;
                try
                {
                    y = byte.Parse(textBoxPosY.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Invalid Number");
                    textBoxPosY.Text = string.Format("{0}", doc.posY);
                    return;
                }
                doc.posY = y;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }

        private void OnPartyValueChangedSteps(object sender, EventArgs e)
        {
            Console.WriteLine("U3CharacerEditorControl.cs: OnPartyValueChangedSteps()");
            if (doc != null)
            {
                uint steps;
                try
                {
                    steps = uint.Parse(textBoxSteps.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Invalid Number");
                    textBoxSteps.Text = string.Format("{0}", doc.steps);
                    return;
                }
                doc.steps = steps;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }

        private void radioButtonOnFoot_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                doc.status = (byte)Ultima3Doc.tileType.RANGER;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }

        private void radioButtonHorse_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                doc.status = (byte)Ultima3Doc.tileType.HORSE;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }

        private void radioButtonFrigate_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                doc.status = (byte)Ultima3Doc.tileType.FRIGATE;
            }
            Console.WriteLine("x={0}, y={1}, status={2}", doc.posX, doc.posY, doc.status);
        }
    }
}
