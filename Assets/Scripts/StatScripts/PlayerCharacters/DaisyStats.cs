using UnityEngine;

public class DaisyStats: CharacterStats
{
    // Variables
    public float expMultiplier;

    public DaisyStats() 
    {
        InitializeStats();
        Villager.ApplyMultipliers(this);
    }

    public DaisyStats(string name, Texture2D image) 
    {
        InitializeStats(name, image);
        Villager.ApplyMultipliers(this);
    }

    protected override void InitializeStats() 
    {
        characterName = "Daisy";
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

        hp = 80;
        attack = 10;
        dexterity = 5;
        intelligence = 20;
        speed = 110;
        
        expMultiplier = 1;
        friend = true;
    
        this.image = image;
    }
}
