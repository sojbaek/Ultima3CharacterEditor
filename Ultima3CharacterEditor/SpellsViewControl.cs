using System;
using System.Collections;
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
    public partial class SpellsViewControl : UserControl
    {
        
        public SpellsViewControl()
        {
            InitializeComponent();

            var wizSpells = from Ultima3Doc.Spell c in Ultima3Doc.spellData
                            where c.type == "wizard" & c.point > 15
                            select c;

            BindingSource source = new BindingSource();
            source.DataSource = wizSpells;
            dataGridView1.DataSource = source;
            
        }
    }
}
