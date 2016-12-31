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
    public partial class FormMain : Form
    {
        const int NumCharacter = 20;
        const string rosterFilename = "../../Roster_test.ult";

        String[][] characterTable;

        int currentCharacterIndex = 0;

        public Character[] Roster { get; set; }

        public FormMain()
        {
            InitializeComponent();
            //MultiplicationTableSetup();
            RosterSetup();
        }

        private void RosterSetup()
        {
            Roster = new Character[NumCharacter];
            characterTable = new String[NumCharacter][];
            for (int i = 0; i < NumCharacter; i++)
            {
                characterTable[i] = new String[4];
            }
            ReadRoster();
        }

        public void ReadRoster()
        {
            if (File.Exists(rosterFilename))
            {
                bool isNotNull;

                using (BinaryReader reader = new BinaryReader(File.Open(rosterFilename, FileMode.Open)))
                {
                    for (int kk = 0; kk < NumCharacter; kk++)
                    {
                        Character C = new Character();
                        isNotNull = C.readCharacterFromBinaryReader(reader);
                        if (isNotNull)
                        {
                            C.print();
                            Roster[kk] = C;
                        } else
                        {
                            Roster[kk] = null;
                        }
                    }
                }

            }
        }

        public void refreshTableRow(int i)
        {
            Console.WriteLine("FormMain.cs:refreshTableRow()");
            if (Roster[i] != null)
            {
                characterTable[i][0] = Roster[i].Name;
                characterTable[i][1] = ((char)Roster[i].Sex).ToString();
                characterTable[i][2] = ((char)Roster[i].Race).ToString();
                characterTable[i][3] = ((char)Roster[i].Profession).ToString();

                dgvRoster.Rows[i].SetValues(characterTable[i]);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("FormMain.cs:FormMain_Load()");
            ucCharacter.roster = this.Roster;
            ucCharacter.parent = this;
            ucCharacter.Update(currentCharacterIndex);
            dgvRoster.Rows.Add(NumCharacter);
            for (int i = 0; i < 20; i++)
            {
                refreshTableRow(i);
                dgvRoster.Rows[i].HeaderCell.Value = Convert.ToString(i+1);
                
            }

            
        }

        private void dgvRoster_RowSelected(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("FormMain.cs:dgvRoster_CellContentClick()");
            if (e.RowIndex != currentCharacterIndex)
            {
                ucCharacter.SaveCharacter(currentCharacterIndex);
                refreshTableRow(currentCharacterIndex);
                if (e.RowIndex >= 0 && e.RowIndex < 20)
                {
                    currentCharacterIndex = e.RowIndex;
                    ucCharacter.Update(currentCharacterIndex);
                }
            }
        }
    }
}
