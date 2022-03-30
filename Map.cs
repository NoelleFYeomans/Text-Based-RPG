using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {
        public string[] mapRawData; //consider a settings page

        private string impassableChars = "#~^"; //add new impassible/wall charavters here <<<<<<<<<<<<<<<<<<

        private int x;
        private int y;
        private int width;
        private int height;


        public bool doorOpen = false;

        public Map()
        {
            mapRawData = System.IO.File.ReadAllLines("map.txt");

            Console.SetBufferSize((mapRawData[0].Length * 3), (mapRawData.Length * 3));//sets actual world border size
            //Console.SetWindowSize(32, 30);
        }

        public void Update() //future use
        {

        }

        public bool isImpassableObstacle(int y, int x) 
        {
            for (int i = 0; i <= impassableChars.Length - 1; i++)
            {
                if (mapRawData[y][x] == impassableChars[i])
                {
                    return true;
                }
                else
                {
                    
                }
            }
            return false;
        }

        public bool isDoor(int y, int x)
        {
            if (mapRawData[y][x] == 'D')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenDoor()
        {
            doorOpen = true;
        }

        public void Draw(Camera camera, Renderer renderer)
        {
            width = mapRawData[0].Length;
            height = mapRawData.Length;

            for (y = 0; y <= height - 1; y++)
            {
                for (x = 0; x <= width - 1; x++)
                {
                    ColourMap();
                    renderer.Draw(x, y, mapRawData[y][x], camera);
                }
                Console.WriteLine("");
            }
        }

        public void ColourMap() //is there a way to make this better/more scalable?
        {
            if (mapRawData[y][x] == '#')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (mapRawData[y][x] == ',')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (mapRawData[y][x] == 'D' && !doorOpen)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (mapRawData[y][x] == 'D' && doorOpen)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (mapRawData[y][x] == '~')
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if (mapRawData[y][x] == 'm')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (mapRawData[y][x] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }
    }
}
