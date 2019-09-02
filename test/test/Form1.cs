﻿using System;
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
        public Form1(List<DocumentType> docList, List<string[]> stringDocList)
        {
            InitializeComponent();
            MakeTable(stringDocList);
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            FillNodes(docList);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void FillNodes(List<DocumentType> list)
        {
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (IsShow(list[i]))
                {
                    TreeNode node = new TreeNode { Text = list[i].name };
                    treeView1.Nodes.Add(node);
                }
            }
        }

        void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            //string[] dirs;
            //    if (Directory.Exists(e.Node.FullPath))
            //    {
            //        dirs = Directory.GetDirectories(e.Node.FullPath);
            //        if (dirs.Length != 0)
            //        {
            //            for (int i = 0; i < dirs.Length; i++)
            //            {
            //                TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
            //                FillTreeNode(dirNode, dirs[i]);
            //                e.Node.Nodes.Add(dirNode);
            //            }
            //        }
            //    }
        }

        private bool IsShow(DocumentType doc)
        {
            if (doc.name != "" && doc.state == 0)
                return true;
            return false;
        }

        private void MakeTable(List<string[]> DocList)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("temp");

            for (int i = 0; i < DocList[0].Length; i++)
                dataSet.Tables[0].Columns.Add(DocList[0][i]);

            for (int i = 1; i < DocList.Count; i++)
                dataSet.Tables[0].Rows.Add(DocList[i]);

            dataGridView1.DataSource = dataSet.Tables[0];
        }        
    }
}
