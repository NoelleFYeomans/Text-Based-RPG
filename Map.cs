﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {
        static char[,] mapArray = new char[,]//temp map
        {
            {'#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#',',',',',',',',',',',',',',',',',',',',','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#'},
        };
        public void Update()
        {

        }
        public void Draw()
        {
            for (int mapY = 0; mapY <= 11; mapY++)
            {
                for (int mapX = 0; mapX <= 11; mapX++)
                {

                }
            }
        }
    }
}
