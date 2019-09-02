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
}