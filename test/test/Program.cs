using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace test
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            CSVParser Parser = new CSVParser();
            string filePath = @"..\..\..\..\DocumentType.csv";
            string regex = ";";

            List<DocumentType> docList = Parser.ParseDataBase(filePath, regex, out string[] header);
            List<string[]> stringDocList = Parser.ParseForTableView(filePath, regex);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.FillNodes(docList);
            form.MakeTable(stringDocList);
            Application.Run(form);
        }
    }
}