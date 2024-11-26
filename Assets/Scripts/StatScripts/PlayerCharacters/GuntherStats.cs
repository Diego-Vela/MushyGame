using UnityEngine;

public class GuntherStats: CharacterStats
{
    // Variables
    public float expMultiplier;

    public GuntherStats() 
    {
        InitializeStats();
        Villager.ApplyMultipliers(this);
    }

    public GuntherStats(string name, Texture2D image) 
    {
        InitializeStats(name, image);
        Villager.ApplyMultipliers(this);
    }

    protected override void InitializeStats() 
    {
        characterName = "Gunther";
        characterClass = "";
        hp = 100;
        attack = 10;
        dexterity = 5;
        intelligence = 8;
        speed = 110;
        expMultiplier = 1;
        friend = true;
    }

    protected override void InitializeStats(string name, Texture2D image) 
    {
        characterName = name;
        characterClass = "";

        hp = 100;
        attack = 35;
        dexterity = 5;
        intelligence = 8;
        speed = 80;
        
        expMultiplier = 1;
        friend = true;
    
        this.image = image;
    }
}
