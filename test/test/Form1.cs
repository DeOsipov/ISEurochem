using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1(List<DocumentType> docList, List<string[]> stringDocList)
        {
            InitializeComponent();
            MakeTable(stringDocList);
            FillTreeViewNodes(BuildTree(docList));
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        static List<DocumentType> BuildTree(List<DocumentType> nodes)
        {
            var nodeMap = nodes.ToDictionary(node => node.id);
            var rootNodes = new List<DocumentType>();

            foreach (var node in nodes)
            {
                if (nodeMap.TryGetValue(node.parentId, out DocumentType parent))
                {
                    foreach (var n in nodes)
                        if (n.id == node.parentId)
                        {
                            parent = n;
                            break;
                        }
                    parent.child.Add(node);
                }
                else
                    rootNodes.Add(node);
            }
            return rootNodes;
        }

        public void FillTreeViewNodes(List<DocumentType> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (IsShow(list[i]))
                {
                    var node = new TreeNode { Text = list[i].name };
                    FillNode(node, list[i]);
                    treeView1.Nodes.Add(node);
                }
        }

        private void FillNode(TreeNode node, DocumentType doc)
        {
            foreach (var n in doc.child)
            {
                var childNode = new TreeNode() { Text = doc.name };
                node.Nodes.Add(childNode);
            }
        }

        private bool IsShow(DocumentType doc)
        {
            if (doc.name != "" && doc.state == 0)
                return true;
            return false;
        }

        private bool HasChild(DocumentType doc)
        {
            if (doc.child != null)
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
