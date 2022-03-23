using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map //camera is an offset
    {
        //maybe map constructor?

        private string[] mapRawData = System.IO.File.ReadAllLines("map.txt"); //consider a settings page //Process is terminated due to StackOverflowException

        private string impassableChars = "#~^"; //add new impassible/wall charavters here <<<<<<<<<<<<<<<<<<

        private int x;
        private int y;
        private int width;
        private int height;


        public bool doorOpen = false;

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

        public void ColourMap() //fix this btw, this ugly & bad
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
