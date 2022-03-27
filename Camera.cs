using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        private string[] map;

        public Camera(GlobalSettings global) {

            this.map = global.mapRawData;

        }

        //so knowing that the camera starts printing from the top left of the screen, offset it's start point from player x/y, and have it adaptively move w/ player coordinates. limit printing to a 7 x 7 area around the player
        //change camera top w/ player deltaY, & left w/ player x

        //buffer is how big the world can be
        //window size is how much the player sees

        public void Draw(Player player) //probably a dud
        {
            Console.SetCursorPosition(Clamp(player.x - 7, 0, map[0].Length), Clamp(player.y - 7, 0, map.Length));

            for (int y = Clamp(player.y - 7, 0, map.Length); y <= Clamp(player.y + 7, 0, map.Length); y++) //15 x 15 being 7 behind, the current ocupied collumn, and 7 in front
            {
                for (int x = Clamp(player.x - 7, 0, map[0].Length); x <= Clamp(player.y + 7, 0, map[0].Length); x++) //15 x 15 being 7 above, the current occupied row, and 7 below
                {
                    //ColourMap();
                    Console.Write(map[y][x]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("");
            }
        }

        protected int Clamp(int value, int minValue, int maxValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }
            if (value < minValue)
            {
                value = minValue;
            }
            return value;
        }
    }

}
