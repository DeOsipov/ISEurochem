namespace test
{
    interface IComparer<DocumentType>
    {
        int Compare(DocumentType doc1, DocumentType doc2);
    }

    class NameComparer : IComparer<DocumentType>
    {
        public int Compare(DocumentType doc1, DocumentType doc2)
        {
            return string.Compare(doc1.name, doc2.name);
        }
    }
}