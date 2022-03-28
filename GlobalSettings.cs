using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GlobalSettings //list of things that are hardcoded/settings that can be changed easily here
    {
        public string[] mapRawData = System.IO.File.ReadAllLines("map.txt");
    }
}
