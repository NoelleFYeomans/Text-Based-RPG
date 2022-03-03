using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
        static GameManager gameManager = new GameManager();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            gameManager.gameLoop();
        }
    }
}
