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

        public void PositionCam(int x, int y) //camera position
        {
            //adjust camera offset //this isn't correct
            this.x = x;
            this.y = y;

            //centers camera
            this.x += Console.BufferWidth / 2;
            this.y += Console.BufferHeight / 2;

            if (this.x < 0 || this.y < 0 || this.x > Console.BufferWidth || this.y > Console.BufferHeight) return;

            //Console.SetCursorPosition(this.x, this.y);
            //Console.Write();
        }

        //so knowing that the camera starts printing from the top left of the screen, offset it's start point from player x/y, and have it adaptively move w/ player coordinates.
        //change camera top w/ player deltaY, & left w/ player deltaX

        //buffer is how big the world can be
        //window size is how much the player sees
    }

}
