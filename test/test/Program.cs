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
            List<string[]> DocList = Parser.ParseDataBase(@"..\..\..\..\DocumentType.csv", ";");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.MakeTable(DocList);
            Application.Run(form);
        }
    }
}