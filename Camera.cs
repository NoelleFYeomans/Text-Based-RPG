using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        public int x;
        public int y;

        public int height;
        public int width;

        public Camera(Player player, GlobalSettings global) //fix initial camera draw & Y axis stutter & outside border printing
        {
            PositionCam(player.x, player.y);

            height = global.camHeight;
            width = global.camWidth;
        }

        public void PositionCam(int x, int y) //camera position
        {
            this.x = x;
            this.y = y;
        }

        //so knowing that the camera starts printing from the top left of the screen, offset it's start point from player x/y, and have it adaptively move w/ player coordinates.
        //change camera top w/ player deltaY, & left w/ player deltaX

        //buffer is how big the world can be
        //window size is how much the player sees
    }

}
