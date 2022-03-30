using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Enemy : GameCharacter //To make a new enemy, add a new subclass
    {
        public bool recentTarget;

        public void Update(Map map, Player player, EnemyManager enemyManager)
        {
            
        }

        public void CalculateAction(Map map, Player player, EnemyManager enemyManager) 
        {
            if (map.isImpassableObstacle(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
            }

            if (map.isDoor(y + deltaY, x + deltaX))
            {
                canMove = false;
            }

            if (enemyManager.IsCoordinatesOccupied(x, deltaX, y, deltaY))
            {
                canMove = false;
            }

            if (x + deltaX == player.x && y + deltaY == player.y) 
            {
                canMove = false;
                doAttack = true;

                for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++) //might be a better place for this?
                {
                    enemyManager.enemyArray[i].recentTarget = false;
                }

                recentTarget = true;
            }

            if (doAttack)
            {
                player.TakeDamage(initalizeStrength);
                MakeBeep(1000, 100); 
                doAttack = false;
            }
        }
    }
}

