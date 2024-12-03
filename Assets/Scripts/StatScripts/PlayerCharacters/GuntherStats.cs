using UnityEngine;

public class GuntherStats: CharacterStats
{
    public GuntherStats() 
    {
        InitializeStats();
    }

    public GuntherStats(Texture2D image) 
    {
        InitializeStats(image);
    }

    protected override void InitializeStats(Texture2D image) 
    {
        characterName = "Gunther";
        characterClass = "";

        this.hp = 175;
        this.currentHp = this.hp;

        this.attack = 30;
        this.dexterity = 5;
        this.intelligence = 5;
        this.speed = 80;
        
        this.level = 1;
        this.expMultiplier = 1;
        this.expToNextLevel = 10;
        this.currentExp = 0;

        this.friend = true;
    
        this.image = image;
    }
}
