using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameObject
    {
        public int y; 
        public int x;
        
        protected char objectIcon;
        protected int initializeX;
        protected int initializeY;

        public void MakeBeep(int freq, int dur)
        {
            Console.Beep(freq, dur);
        }
    }
}
