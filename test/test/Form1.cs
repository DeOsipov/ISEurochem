using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1(List<DocumentType> docList, List<string[]> stringDocList, IComparer<DocumentType> nameComparer)
        {
            InitializeComponent();
            MakeTable(stringDocList);
            FillTreeViewNodes(BuildTree(SortByParentId(docList), nameComparer));
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        List<DocumentType> BuildTree(List<DocumentType> sortList, IComparer<DocumentType> nameComparer)
        {
            var rootNodes = new List<DocumentType>();

            foreach (var node in sortList)
            {          
                var parent = GetParent(sortList, node);
                if (parent != null)
                    parent.child.Add(node);
                else
                    rootNodes.Add(node);
            }
            
            foreach (var elem in rootNodes)
                Sort(elem, nameComparer);
            rootNodes.Sort(nameComparer);
            return rootNodes;
        }

        void Sort(DocumentType doc, IComparer<DocumentType> nameComparer)
        {
            if (doc.child.Count != 0)
                foreach (var elem in doc.child)
                    Sort(elem, nameComparer);
            doc.child.Sort(nameComparer);
        }

        public void FillTreeViewNodes(List<DocumentType> list)
        {
            foreach(var doc in list)
                if (IsShow(doc))
                {
                    var node = new TreeNode { Text = doc.name };
                    FillNode(node, doc);
                    treeView1.Nodes.Add(node);
                }
        }

        private void FillNode(TreeNode node, DocumentType doc)
        {
            if (doc.child.Count != 0)
                foreach (var elem in doc.child)
                    if (IsShow(elem))
                    {
                        var childNode = new TreeNode() { Text = elem.name };
                        FillNode(childNode, elem);
                        node.Nodes.Add(childNode);
                    }  
        }

        private bool IsShow(DocumentType doc)
        {
            if (doc.name != "" && doc.state == 0)
                return true;
            return false;
        }

        DocumentType GetParent(List<DocumentType> list, DocumentType doc)
        {
            foreach (var elem in list)
                if (doc.parentId == elem.id && elem.id != 1)
                    return elem;
            return null;
        }

        List<DocumentType> SortByParentId(List<DocumentType> docList)
        {
            IComparer<DocumentType> parentIDComparer = new ParentIDComparer();
            docList.Sort(parentIDComparer);
            return docList;
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
