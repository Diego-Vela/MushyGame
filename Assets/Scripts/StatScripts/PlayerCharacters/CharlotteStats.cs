using UnityEngine;

public class CharlotteStats: CharacterStats
{
    public CharlotteStats() 
    {
        InitializeStats();
    }

    public CharlotteStats(Texture2D image) 
    {
        InitializeStats(image);
    }

    protected override void InitializeStats(Texture2D image) 
    {
        characterName = "Charlotte";
        characterClass = "";

        this.hp = 100;
        this.currentHp = this.hp;

        this.attack = 12;
        this.dexterity = 5;
        this.intelligence = 8;
        this.speed = 135;
        
        this.level = 1;
        this.expMultiplier = 1;
        this.expToNextLevel = 10;
        this.currentExp = 0;

        this.friend = true;
    
        this.image = image;
    }
}
