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
        }

        public void FillNodes(List<DocumentType> list)
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

        private bool IsShow(DocumentType doc)
        {
            if (doc.name != "" && doc.state == 0)
                return true;
            return false;
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
