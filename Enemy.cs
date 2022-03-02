using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Enemy : GameCharacter //NEEDS TO BE UPDATED BY STANDARD OF PLAYER
    {
        protected char enemyIcon;
        protected int initializeX;
        protected int initializeY;
        protected int initalizeStrength;

        public void CalculateAction(Map map, Player player, Enemy enemy, Enemy enemy2)
        {
            if (map.isWall(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
            }

            if (x + deltaX == player.x && y + deltaY == player.y || x + deltaX == enemy.x && y + deltaY == enemy.y || x + deltaX == enemy2.x && y + deltaY == enemy2.y)
            {
                canMove = false;

                if (x + deltaX == player.x && y + deltaY == player.y) //this is so f-ing messy
                {
                    doAttack = true;
                }
            }

            if (doAttack)
            {
                player.TakeDamage(initalizeStrength); //temp hardcode
                doAttack = false;
            }
        }

        public void ApplyAction()
        {
            if (canMove) //enemy stops moving when attacked or if it attacks
            {
                x = x + deltaX;
                y = y + deltaY;

                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);
            }
        }
        public void InitializeEnemy(char icon, int initX, int initY, int health, int strength)
        {
            enemyIcon = icon;
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y); //fix
                Console.Write(enemyIcon);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (!isAlive) //needs to be changed
            {
                x = 0;
                y = 0;
            }
        }
    }
}

