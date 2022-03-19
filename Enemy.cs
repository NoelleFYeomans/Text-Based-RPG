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
                //MakeBeep(500, 100); //this is the sound error

                if (x + deltaX == player.x && y + deltaY == player.y) //this is so  messy
                {
                    doAttack = true;
                }
            }

            if (doAttack)
            {
                player.TakeDamage(initalizeStrength); //temp hardcode
                MakeBeep(1000, 100); //beeps if bumps into player, then beeps again if attacks
                doAttack = false;
            }
        }
    }
}

