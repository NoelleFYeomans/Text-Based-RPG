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

        public int winY;
        public int winX;
        public int deltaX;
        public int deltaY;
        public int bufferX;
        public int bufferY;

        public Camera(GlobalSettings global) {

            this.map = global.mapRawData;

            winY = global.mapRawData.Length + 5;
            winX = global.mapRawData[0].Length / 3;
            bufferX = 140;
            bufferY = 60;
            deltaX = 0;
            deltaY = 0;

            Console.SetBufferSize(bufferX, bufferY);
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(winX, winY);

        }

        public void tempMethod(Player player) //renderer
        {
            Console.SetWindowPosition(Clamp(player.x - 10, 0, 120), Clamp(player.y - 10, 0, 30));
        }

        public void PositionCam()
        {

        }
        //consolidate all draws into a render.draw class&method/camera.position class&method

        public bool isCameraInbounds(int x, int y)
        {
            if (x < Console.WindowLeft || x > Console.WindowLeft + map[0].Length || y < Console.WindowTop || y > Console.WindowTop + map.Length)
            {
                return false;
            }

            return true;
        }

        public void UpdateCamera(Player player)
        {
            if (player.y + player.deltaY > player.priorPositionY && player.x != player.priorPositionX && player.y != player.priorPositionY)
            {
                deltaX = 0;
                deltaY = 1;
            }
            else if (player.y + player.deltaY < player.priorPositionY && player.x != player.priorPositionX && player.y != player.priorPositionY)
            {
                deltaX = 0;
                deltaY = -1;
            }
            else if (player.x + player.deltaX < player.priorPositionX && player.x != player.priorPositionX && player.y != player.priorPositionY)
            {
                deltaX = -1;
                deltaY = 0;
            }
            else if (player.x + player.deltaX > player.priorPositionX && player.x != player.priorPositionX && player.y != player.priorPositionY)
            {
                deltaX = 1;
                deltaY = 0;
            }
            else
            {
                deltaX = 0;
                deltaY = 0;
            }

            if (0 <= Console.WindowLeft + deltaX && Console.WindowLeft + deltaX <= bufferX && 0 <= Console.WindowTop + deltaY && Console.WindowTop + deltaY <= bufferY)
            {
                Console.WindowLeft = Console.WindowLeft + deltaX;
                Console.WindowTop = Console.WindowTop + deltaY;
                Console.SetWindowPosition(Clamp(player.x - 20, 0, player.x - 20), Clamp(player.y - 10, 0, player.y - 10));
            }
            //fix hud using Console.WindowLeft
        }

        //so knowing that the camera starts printing from the top left of the screen, offset it's start point from player x/y, and have it adaptively move w/ player coordinates. limit printing to a 7 x 7 area around the player
        //change camera top w/ player deltaY, & left w/ player x

        //buffer is how big the world can be
        //window size is how much the player sees

        void hider()
        {

        //public void Draw(Player player) //probably a dud
        //{
        //    Console.SetCursorPosition(Clamp(player.x - 7, 0, map[0].Length), Clamp(player.y - 7, 0, map.Length));

        //    for (int y = Clamp(player.y - 7, 0, map.Length); y <= Clamp(player.y + 7, 0, map.Length); y++) //15 x 15 being 7 behind, the current ocupied collumn, and 7 in front
        //    {
        //        for (int x = Clamp(player.x - 7, 0, map[0].Length); x <= Clamp(player.y + 7, 0, map[0].Length); x++) //15 x 15 being 7 above, the current occupied row, and 7 below
        //        {
        //            //ColourMap();
        //            Console.Write(map[y][x]);
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        Console.WriteLine("");
        //    }
        //}
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
