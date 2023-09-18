﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GlobalSettings //list of things that are hardcoded/settings that can be changed easily here
    {
        //Ingame Camera Dimension //deal with constants
        public int camHeight = 14;
        public int camWidth = 28;

        //Obstacle Characters in Map.cs
        public string impassableChars = "#~^"; //add/remove char to change collision detection

        //Player stats
        public char playerObjectIcon = '@';
        public int playerHealth = 100;
        public int playerInitStrength = 25;
        public int playerSpawnX = 30;
        public int playerSpawnY = 7;

        //WeakEnemy stats
        public char weakObjectIcon = 'W';
        public int weakHealth = 50;
        public int weakInitStrength = 1;
        public int weakGold = 1;

        //NormalEnemy stats
        public char normalObjectIcon = 'E';
        public int normalHealth = 100;
        public int normalInitStrength = 5;
        public int normalGold = 5;

        //StrongEnemy stats
        public char strongObjectIcon = 'S';
        public int strongHealth = 150;
        public int strongInitStrength = 10;
        public int strongGold = 10;

        //ShopKeeper
        public char shopObjectIcon = '$';
        public int potionCost = 10;
        public int shopCount = 1;
        public int[] shopPosX = new int[1] { 3 }; //sample second coords 5, 5
        public int[] shopPosY = new int[1] { 21 };

        //ShopKeeper
        public char questGiverObjectIcon = '!';
        public int questGiverCount = 1;
        public int[] giverPosX = new int[1] { 8 }; //sample second coords 7, 5
        public int[] giverPosY = new int[1] { 21 };
        public Quest[] quests = new Quest[1] { 
            new Quest(Quest.Category.Collection, Quest.Target.Potions, 5, "Side Quest: Collect 5 Potions", 25) /*, 
            new Quest(Quest.Category.Elimination, Quest.Target.NormalEnemies, 5, "Side Quest: Kill 5 Normal Enemies", 50)*/ };


        //Item Stats/Data
        public int healthBoost = 25;
        public char hBoostIcon = 'P';
        public int attackBoost = 25;
        public char aBoostIcon = 'A';
        public char keyIcon = 'K';



    }
}
