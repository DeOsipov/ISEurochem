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
            IParser Parser = new CSVParser();
            string filePath = @"..\..\..\..\DocumentType.csv";
            string regex = ";";

            List<string[]> DocList = Parser.ParseDataBase(filePath, regex);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}