using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Enemy : GameCharacter
    {
        public bool recentTarget;

        public void CalculateAction(Map map, Player player, Enemy enemy, Enemy enemy2)
        {
            if (map.isImpassableObstacle(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
            }
            if (map.isDoor(y + deltaY, x + deltaX))
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
    }
}

