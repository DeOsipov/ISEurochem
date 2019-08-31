using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void FillDriveNodes(List<string[]> list)
        {
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (IsShow(list[i]))
                {
                    TreeNode node = new TreeNode { Text = list[i][1] };
                    treeView1.Nodes.Add(node);
                }                
            }
        }

        private bool IsShow(string[] doc)
        {
            if (doc[1] != "" && doc[7] == "0")
                return true;
            return false;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        public void MakeTable(List<string[]> DocList)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("temp");

            for (int i = 0; i < DocList[0].Length; i++)
                dataSet.Tables[0].Columns.Add(DocList[0][i]);

            for (int i = 1; i < DocList.Count; i++)
                dataSet.Tables[0].Rows.Add(DocList[i]);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}