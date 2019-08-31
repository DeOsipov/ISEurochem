using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    interface IParser
    {
        List<DocumentType> ParseDataBase(string filePath, string regex, out string[] header);
    }
}
