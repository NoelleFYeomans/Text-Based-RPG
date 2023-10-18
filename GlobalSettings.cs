using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Text_Based_RPG;

public class GlobalSettings
{
    public static GlobalSettings LoadFromJson(string jsonFilePath)
    {
        string jsonData = File.ReadAllText(jsonFilePath);
        //Console.WriteLine(jsonData);
        //Console.ReadKey(true);
        return JsonSerializer.Deserialize<GlobalSettings>(jsonData);

    }

    //camera
    public int camHeight { get; set; }// = 14;
    public int camWidth { get; set; }// = 28;

    //wall characters
    public string impassableChars { get; set; }// = "#~^";

    //player
    public char playerObjectIcon { get; set; }
    public int playerHealth { get; set; }// = 100;
    public int playerInitStrength { get; set; }
    public int playerSpawnX { get; set; }// = 30;
    public int playerSpawnY { get; set; }// = 7;

    //weak enemy
    public char weakObjectIcon { get; set; }
    public int weakHealth { get; set; }// = 1;
    public int weakInitStrength { get; set; }
    public int weakGold { get; set; }

    //normal enemy
    public char normalObjectIcon { get; set; }
    public int normalHealth { get; set; }
    public int normalInitStrength { get; set; }
    public int normalGold { get; set; }

    //strong enemy
    public char strongObjectIcon { get; set; }
    public int strongHealth { get; set; }
    public int strongInitStrength { get; set; }
    public int strongGold { get; set; }

    //shops
    public char shopObjectIcon { get; set; }
    public int shopCount { get; set; }
    public int[] shopPosX { get; set; }
    public int[] shopPosY { get; set; }
    public List<Shop.Merch>[] shopMerchs { get; set; }
    public List<int>[] shopCosts { get; set; }

    //quest
    public char questGiverObjectIcon { get; set; }
    public int questGiverCount { get; set; }
    public int[] giverPosX { get; set; }
    public int[] giverPosY { get; set; }
    public Quest[] quests { get; set; }

    //items
    public int healthBoost { get; set; }
    public char hBoostIcon { get; set; }
    public int attackBoost { get; set; }
    public char aBoostIcon { get; set; }
    public char keyIcon { get; set; }
}
