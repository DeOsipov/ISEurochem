using System.Collections.Generic;

namespace test
{
    class NameComparer : IComparer<DocumentType>
    {
        public int Compare(DocumentType doc1, DocumentType doc2)
        {            
            return string.Compare(doc1.name, doc2.name); ;
        }
    }

    class ParentIDComparer : IComparer<DocumentType>
    {
        public int Compare(DocumentType doc1, DocumentType doc2)
        {
            if (doc1.parentId > doc2.parentId)
                return 1;
            else if (doc1.parentId < doc2.parentId)
                return -1;
            return 0;
        }
    }
}