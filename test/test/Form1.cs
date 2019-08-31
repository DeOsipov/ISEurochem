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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MakeTable(DocList); //here
        }

        private void Form1_Load(object sender, EventArgs e) { }

        public void MakeTable(List<string[]> DocList)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("temp");
            
            //for (int i = 0; i < DocList[0].Length; i++)
            //    dataSet.Tables[0].Columns.Add(DocList[0][i]);

            for (int i = 0; i < DocList.Count; i++)
                dataSet.Tables[0].Rows.Add(DocList[i]);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}