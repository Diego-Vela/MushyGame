using UnityEngine;

public class CharlotteStats: CharacterStats
{
    // Variables
    public float expMultiplier;

    public CharlotteStats() 
    {
        InitializeStats();
        Villager.ApplyMultipliers(this);
    }

    public CharlotteStats(string name, Texture2D image) 
    {
        InitializeStats(name, image);
        Villager.ApplyMultipliers(this);
    }

    protected override void InitializeStats() 
    {
        characterName = "Charlotte";
        characterClass = "";
        hp = 100;
        attack = 10;
        dexterity = 5;
        intelligence = 8;
        speed = 100;
        expMultiplier = 1;
        friend = true;
    }

    protected override void InitializeStats(string name, Texture2D image) 
    {
        characterName = name;
        characterClass = "";

        hp = 100;
        attack = 12;
        dexterity = 5;
        intelligence = 8;
        speed = 135;
        
        expMultiplier = 1;
        friend = true;
    
        this.image = image;
    }
}
