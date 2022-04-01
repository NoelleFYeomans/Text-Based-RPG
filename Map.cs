using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {
        public string[] mapRawData;

        private string impassableChars;

        private int x;
        private int y;
        private int width;
        private int height;


        public bool doorOpen = false;
        public bool ironDoorOpen = false;

        public Map(GlobalSettings global)
        {
            mapRawData = System.IO.File.ReadAllLines("map.txt");
            impassableChars = global.impassableChars;

            Console.SetBufferSize((mapRawData[0].Length * 3), (mapRawData.Length * 4));//sets actual world border size
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
            if (mapRawData[y][x] == 'D' || mapRawData[y][x] == 'I')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isInsideStructure(int y, int x)
        {
            if (mapRawData[y][x] == 'm' || mapRawData[y][x] == 'B' || mapRawData[y][x] == 'o')
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

        public void OpenIronDoor()
        {
            ironDoorOpen = true;
        }

        public void Draw(Camera camera, Renderer renderer)
        {
            width = mapRawData[0].Length;
            height = mapRawData.Length;

            for (y = 0; y <= height - 1; y++)
            {
                for (x = 0; x <= width - 1; x++)
                {
                    renderer.Draw(x, y, mapRawData[y][x], camera, ColourMap());
                }
                Console.WriteLine("");
            }
        }

        public ConsoleColor ColourMap() //is there a way to make this better/more scalable?
        {
            if (mapRawData[y][x] == '#')
            {
                return ConsoleColor.Cyan;
            }
            else if (mapRawData[y][x] == ',')
            {
                return ConsoleColor.Green;
            }
            else if ((mapRawData[y][x] == 'D' && !doorOpen) || (mapRawData[y][x] == 'I' && !ironDoorOpen))
            {
                return ConsoleColor.DarkYellow;
            }
            else if ((mapRawData[y][x] == 'D' && doorOpen) || (mapRawData[y][x] == 'I' && ironDoorOpen))
            {
                return ConsoleColor.Yellow;
            }
            else if (mapRawData[y][x] == '~')
            {
                return ConsoleColor.DarkBlue;
            }
            else if (mapRawData[y][x] == 'm' || mapRawData[y][x] == 'o')
            {
                return ConsoleColor.Gray;
            }
            else if (mapRawData[y][x] == '^')
            {
                return ConsoleColor.DarkGray;
            }
            return ConsoleColor.White;
        }
    }
}
