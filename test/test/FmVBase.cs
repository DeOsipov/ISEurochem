using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace test
{
    class FmVBase
    {
        internal string Path { get; set; }        

        internal FmVBase GetForm(MyTreeNode doc)
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

        internal void TryOpenWord(FmVBase form)
        {
            try
            {
                RunWordApp(form);
            }
            catch
            {
                MessageBox.Show("File is missing");
            }
        }

        void RunWordApp(FmVBase form)
        {
            int LengthOfUnusingPath = 19;
            object oMissing = Missing.Value;
            string path = Directory.GetCurrentDirectory();
            object oTemplate = path.Substring(0, path.Length - LengthOfUnusingPath) + form.Path;
            Word._Application oWord = new Word.Application { Visible = true };
            Word._Document oDoc;
            oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
        }
    }

    class FmVMemorandum : FmVBase
    {
        internal FmVMemorandum(string path)
        {
            Path = path;
        }
    }
    class FmVStatement : FmVBase
    {
        internal FmVStatement(string path)
        {
            Path = path;
        }
    }
    class FmVRequest : FmVBase
    {
        internal FmVRequest(string path)
        {
            Path = path;
        }
    }
    class FmVBill : FmVBase
    {
        internal FmVBill(string path)
        {
            Path = path;
        }
    }
}