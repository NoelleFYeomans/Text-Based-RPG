using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Text_Based_RPG;
using static Text_Based_RPG.Quest;
using static Text_Based_RPG.Shop;

public class GlobalSettings
{
    public static GlobalSettings LoadFromJson(string jsonFilePath)
    {
        string jsonData = File.ReadAllText(jsonFilePath);

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Converters = { new CategoryConverter(), new TargetConverter(), new MerchConverter(), new QuestConverter() },
        };

        return JsonSerializer.Deserialize<GlobalSettings>(jsonData, options);
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

public class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string categoryString = reader.GetString();
            if (Enum.TryParse(categoryString, out Category result))
            {
                return result;
            }
        }

        throw new JsonException($"Unable to convert value to enum {typeToConvert.Name}");
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

public class TargetConverter : JsonConverter<Target>
{
    public override Target Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string targetString = reader.GetString();
            if (Enum.TryParse(targetString, out Target result))
            {
                return result;
            }
        }

        throw new JsonException($"Unable to convert value to enum {typeToConvert.Name}");
    }

    public override void Write(Utf8JsonWriter writer, Target value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

public class MerchConverter : JsonConverter<Merch>
{
    public override Merch Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string merchString = reader.GetString();
            if (Enum.TryParse(merchString, out Merch result))
            {
                return result;
            }
        }

        throw new JsonException($"Unable to convert value to enum {typeToConvert.Name}");
    }

    public override void Write(Utf8JsonWriter writer, Merch value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
public class QuestConverter : JsonConverter<Quest>
{
    public override Quest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            Category questType = (Category)Enum.Parse(typeof(Category), root.GetProperty("category").GetString());
            Target questTarget = (Target)Enum.Parse(typeof(Target), root.GetProperty("target").GetString());
            int amount = root.GetProperty("requiredAmount").GetInt32();
            string message = root.GetProperty("description").GetString();
            int rewardGold = root.GetProperty("reward").GetInt32();

            return new Quest(questType, questTarget, amount, message, rewardGold);
        }
    }

    public override void Write(Utf8JsonWriter writer, Quest value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}