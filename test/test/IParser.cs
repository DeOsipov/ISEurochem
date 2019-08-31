using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    interface IParserInListOfObject
    {
        List<DocumentType> ParseDataBase(string filePath, string regex, out string[] header);
    }

    interface IParserInStringArray
    {
        List<string[]> ParseForTableView(string filePath, string regex);
    }

    class CSVParser : IParserInListOfObject, IParserInStringArray
    {
        public List<DocumentType> ParseDataBase(string filePath, string regex, out string[] header)
        {
            List<DocumentType> tempList = new List<DocumentType> { };
            Regex CSVParser = new Regex(regex);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                header = CSVParser.Split(firstLine);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    DocumentType tempDoc = new DocumentType();
                    string[] splitLine = CSVParser.Split(line);
                    int counter = 0;

                    tempDoc.id = int.Parse(splitLine[counter++]);
                    tempDoc.name = splitLine[counter++];
                    tempDoc.parentId = int.Parse(splitLine[counter++]);
                    tempDoc.acronym = splitLine[counter++];
                    tempDoc.note = splitLine[counter++];
                    tempDoc.loadingClass = splitLine[counter++];
                    tempDoc.imageId = int.Parse(splitLine[counter++]);
                    tempDoc.state = int.Parse(splitLine[counter++]);
                    tempDoc.modificationDate = splitLine[counter++];
                    tempDoc.modificationUserId = splitLine[counter++];

                    tempList.Add(tempDoc);
                }
            }
            return tempList;
        }

        public List<string[]> ParseForTableView(string filePath, string regex)
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
