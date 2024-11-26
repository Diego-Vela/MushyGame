using UnityEngine;

public class PlayerStats: CharacterStats
{
    // Variables
    public float expMultiplier;

    public PlayerStats() 
    {
        InitializeStats();
        Villager.ApplyMultipliers(this);
    }

    public PlayerStats(string name, Texture2D image) 
    {
        InitializeStats(name, image);
        Villager.ApplyMultipliers(this);
    }

    protected override void InitializeStats() 
    {
        characterName = "Protagonist";
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
        attack = 15;
        dexterity = 5;
        intelligence = 8;
        speed = 100;
        
        expMultiplier = 1;
        friend = true;
    
        this.image = image;
    }
}
