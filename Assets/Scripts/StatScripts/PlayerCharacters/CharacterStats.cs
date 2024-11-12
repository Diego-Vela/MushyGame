using UnityEngine;

public class CharacterStats: Stats
{
    // Variables
    public float expMultiplier;

    public CharacterStats() 
    {
        InitializeStats();
        Villager.ApplyMultipliers(this);
    }

    public CharacterStats(string name, Texture2D image) 
    {
        InitializeStats(name, image);
        Villager.ApplyMultipliers(this);
    }

    protected void InitializeStats() 
    {
        characterName = "Villager";
        characterClass = "";
        hp = 100;
        attack = 10;
        dexterity = 5;
        intelligence = 8;
        speed = 110;
        expMultiplier = 1;
        friend = true;
    }

        protected void InitializeStats(string name, Texture2D image) 
    {
        characterName = name;
        characterClass = "";

        hp = 100;
        attack = 15;
        dexterity = 5;
        intelligence = 8;
        speed = 110;
        
        expMultiplier = 1;
        friend = true;
    
        this.image = image;
    }
}
