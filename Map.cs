using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {

        private string[] mapRawData = System.IO.File.ReadAllLines("map.txt"); //consider a settings page

        private int x;
        private int y;
        private int width;
        private int height;

        public void Update() //future use
        {
            
        }

        public bool isWall(int y, int x) 
        {
            if (mapRawData[y][x] == '#') 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            width = mapRawData[0].Length;
            height = mapRawData.Length;

            for (y = 0; y <= height-1; y++)
            {
                for (x = 0; x <= width-1; x++)
                {
                    ColourMap();
                    Console.Write(mapRawData[y][x]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("");
            }
        }

        public void ColourMap()
        {
            if (mapRawData[y][x] == '#')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (mapRawData[y][x] == ',')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
}
