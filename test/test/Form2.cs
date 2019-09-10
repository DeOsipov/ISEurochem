using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) { }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DocumentType doc = new DocumentType();
            doc.name = textBoxName.Text;
            doc.acronym = textBoxAcronym.Text;

            textBoxName.Clear();
            textBoxAcronym.Clear();
            textBoxNote.Clear();
            dataGridView1.Refresh();
        }
    }
}
