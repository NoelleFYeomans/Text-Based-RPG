using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter : GameObject
    {
        public int health = 100; //protected, needs to be public to visibly test
        public int y; //protected, needs to be public to visibly test
        public int x; //protected, needs to be public to visibly test

        protected bool doAttack = false;
        protected bool canMove = true;
        protected bool isAlive = true;
        protected bool spawning = true;

        protected char charIcon;
        protected int initializeX;
        protected int initializeY;
        protected int initalizeStrength;

        public int priorPositionX;
        public int priorPositionY;
        public int deltaX;
        public int deltaY;

        Random rand = new Random();

        public void TakeDamage(int atk) //has to be public
        {
            atk = Clamp(atk, 0, 1000);
            health = health - atk; //expand
            health = Clamp(health, 0, 100);
        }

        protected void RespawnCharacter() //future use
        {

        }

        public int GenerateRandNum(int minValue, int maxValue)
        {
            int output = rand.Next(minValue, maxValue);
            return output;
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

        public void InitializeCharacter(char icon, int initX, int initY, int health, int strength)
        {
            charIcon = icon;
            initializeX = initX;
            initializeY = initY;
            this.health = health;
            initalizeStrength = strength;
        }

        public void Draw() //could move to GameObject class & apply to player & enemy
        {
            if (spawning) //needs to be changed
            {
                x = initializeX;
                y = initializeY;
                spawning = false;
            }
            if (isAlive)
            {
                if (charIcon == '@')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(x, y); //fix
                    Console.Write(charIcon);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(x, y); //fix
                    Console.Write(charIcon);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else if (!isAlive) //needs to be changed
            {
                x = 0;
                y = 0;
            }
        }
    }
}
