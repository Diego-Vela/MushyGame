using UnityEngine;

public class DaisyStats: CharacterStats
{
    public DaisyStats() 
    {
        InitializeStats();
    }

    public DaisyStats(Texture2D image) 
    {
        InitializeStats(image);
    }

    protected override void InitializeStats(Texture2D image) 
    {
        characterName = "Daisy";
        characterClass = "";

        this.hp = 90;
        this.currentHp = this.hp;

        this.attack = 15;
        this.dexterity = 5;
        this.intelligence = 15;
        this.speed = 110;
        
        this.level = 1;
        this.expMultiplier = 1;
        this.expToNextLevel = 10;
        this.currentExp = 0;

        this.friend = true;
    
        this.image = image;
    }
}
