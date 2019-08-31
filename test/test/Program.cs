using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace test
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            IParser Parser = new CSVParser();
            List<string[]> docList = Parser.ParseDataBase(@"..\..\..\..\DocumentType.csv", ";");    

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.MakeTable(docList);
            form.FillDriveNodes(docList);
            Application.Run(form);
        }
    }
}