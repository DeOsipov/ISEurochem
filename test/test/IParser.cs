﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    interface IParser
    {
        List<string[]> ParseDataBase(string filePath, string regex);
    }
}
