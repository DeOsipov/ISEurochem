using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    class temp
    {
        public void F(List<DocumentType> list)
        {
            BuildTree1(SortByParentId(list));
        }

        List<DocumentType> SortByParentId(List<DocumentType> docList)
        {
            IComparer<DocumentType> parentIDComparer = new ParentIDComparer();
            docList.Sort(parentIDComparer);
            return docList;
        }
        bool HasChild(DocumentType doc)
        {
            if (doc.child != null)
                return true;
            return false;
        }
        DocumentType GetParent(List<DocumentType> list, DocumentType doc)
        {
            foreach (var elem in list)
            {
                if (HasChild(elem))
                    GetParent(elem.child, doc);
                if (doc.parentId == elem.id)
                    return elem;
            }                
            return null;
        }

        List<DocumentType> BuildTree1(List<DocumentType> sortList)
        {
            var rootNodes = new List<DocumentType>();

            foreach (var node in sortList)
            {
                var parent = GetParent(sortList, node);
                if (parent != null)
                    parent.child.Add(node);
                MessageBox.Show(parent.name);
            }
            return rootNodes;
        }
    }
}
