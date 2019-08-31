using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    class CSVParser : IParser
    {
        public List<string[]> ParseDataBase(string filePath, string regex)
        {            
            List<string[]> tempList = new List<string[]> { };
            Regex CSVParser = new Regex(regex);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitLine = CSVParser.Split(line);
                    tempList.Add(splitLine);
                }
            }
            return tempList;
        }
    }
}
