using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

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
            List<string[]> stringDocList = Parser.ParseForTableView(filePath, regex);
            List<DocumentType> docList = Parser.ParseDataBase(filePath, regex, out string[] header);
            IComparer<DocumentType> nameComparer = new NameComparer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(docList, stringDocList, nameComparer));
        }
    }
}