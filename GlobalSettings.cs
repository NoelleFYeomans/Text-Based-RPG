using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GlobalSettings //not really sure what else to put here?
    {
        public string[] mapRawData = System.IO.File.ReadAllLines("map.txt");
    }
}
