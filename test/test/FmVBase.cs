namespace test
{
    class FmVBase
    {
        public string Path { get; set; }

        internal FmVBase GetForm(MyTreeNode doc) //TODO NyTreeNode -> DocumentType
        {
            FmVBase form = null;
            switch (doc.LoadingClass)
            {
                case "fmVMemorandum":
                    form = new FmVMemorandum("memorandum.doc");
                    break;
                case "fmVBill":
                    form = new FmVBill("bill.doc");
                    break;
                case "fmVRequest":
                    form = new FmVRequest("request.doc");
                    break;
                case "fmVStatement":
                    form = new FmVStatement("statement.doc");
                    break;
                default:
                    form = null;
                    break;
            }
            return form;
        }
    }

    class FmVMemorandum : FmVBase
    {
        public FmVMemorandum(string path)
        {
            Path = path;
        }
    }
    class FmVStatement : FmVBase
    {
        public FmVStatement(string path)
        {
            Path = path;
        }
    }
    class FmVRequest : FmVBase
    {
        public FmVRequest(string path)
        {
            Path = path;
        }
    }
    class FmVBill : FmVBase
    {
        public FmVBill(string path)
        {
            Path = path;
        }
    }
}