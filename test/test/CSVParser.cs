﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    class CSVParser : IParser
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

                    tempDoc.id = Int32.Parse(splitLine[counter++]);
                    tempDoc.name = splitLine[counter++];
                    tempDoc.parentId = Int32.Parse(splitLine[counter++]);
                    tempDoc.acronym = splitLine[counter++];
                    tempDoc.note = splitLine[counter++];
                    tempDoc.loadingClass = splitLine[counter++];
                    tempDoc.imageId = Int32.Parse(splitLine[counter++]);
                    tempDoc.state = Int32.Parse(splitLine[counter++]);
                    tempDoc.modificationDate = splitLine[counter++];
                    tempDoc.modificationUserId = splitLine[counter++];

                    tempList.Add(tempDoc);
                }
            }
            return tempList;
        }
    }
}
