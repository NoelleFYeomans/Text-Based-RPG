using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GlobalSettings //put shit in here, I have to make one of these.
    {
        public string[] mapRawData = System.IO.File.ReadAllLines("map.txt");
    }
}
