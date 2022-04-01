using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter : GameObject
    {
        public int health;

        protected bool doAttack = false;
        protected bool canMove = true;
        protected bool isAlive = true;
        protected bool spawning = true;

        protected int minHealth = 0;

        public int initalizeStrength;
        public int priorPositionX;
        public int priorPositionY;
        public int deltaX;
        public int deltaY;

        public void TakeDamage(int atk) //has to be public
        {
            atk = Clamp(atk, 0, 1000);

            health = health - atk;

            if (health <= 0) 
            {
                health = Clamp(health, 0, 100);
                isAlive = false;
            }
        }

        protected void RespawnCharacter() //future use
        {

        }

        public void InitializeCharacterPosition(int initX, int initY)
        {
            x = initX;
            y = initY;
            initializeX = initX;
            initializeY = initY;
        }

        public void ApplyAction(Map map)
        {
            if (canMove)
            {
                Clamp(deltaX, -1, 1);
                Clamp(deltaY, -1, 1);

                x = x + deltaX;
                y = y + deltaY;

                x = Clamp(x, 0, map.mapRawData[0].Length);
                y = Clamp(y, 0, map.mapRawData.Length);
            }
        }

        public void Draw(Camera camera, Renderer renderer)
        {
            if (spawning)
            {
                x = initializeX;
                y = initializeY;
                spawning = false;
            }

            if (isAlive)
            {
                if (objectIcon == '@')
                {
                    renderer.Draw(x, y, objectIcon, camera, ConsoleColor.Magenta);
                }
                else
                {
                    renderer.Draw(x, y, objectIcon, camera, ConsoleColor.DarkRed);
                }
            }

            else if (!isAlive) //cannot make x/y null
            {
                x = 0;
                y = 0;
            }
        }
    }
}
