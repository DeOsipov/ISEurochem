using System.Collections.Generic;

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
}
