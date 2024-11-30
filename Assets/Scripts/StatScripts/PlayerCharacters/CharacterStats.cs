using UnityEngine;

public class CharacterStats: Stats
{
    // Variables
    public float expMultiplier;
    public float expToNextLevel;
    public float currentExp;
    public float currentHp;

    public CharacterStats() 
    {
        InitializeStats();
    }

    public CharacterStats(Texture2D image) 
    {
        InitializeStats(image);
    }

    protected virtual void InitializeStats() 
    {
        this.characterName = "unknownCharacter";
        this.characterClass = "";
        
        this.hp = 100;
        this.currentHp = this.hp;

        this.attack = 10;
        this.dexterity = 5;
        this.intelligence = 8;
        this.speed = 100;

        this.level = 1;
        this.expMultiplier = 1;
        this.expToNextLevel = 10;
        this.currentExp = 0;

        this.friend = true;
    }

    protected virtual void InitializeStats(Texture2D image) 
    {
        characterName = "Protagonist";
        characterClass = "";

        this.hp = 100;
        this.currentHp = this.hp;

        this.attack = 15;
        this.dexterity = 5;
        this.intelligence = 8;
        this.speed = 100;
        
        this.level = 1;
        this.expMultiplier = 1;
        this.expToNextLevel = 10;
        this.currentExp = 0;

        this.friend = true;

        this.image = image;
    }

    public void SetValuesFrom(string characterName, string characterClass, float hp, float attack,
        float dexterity, float intelligence, float speed, int level, float expMultiplier, 
        float expToNextLevel, float currentHp, float currentExp) {
        
        this.characterName = characterName;
        this.characterClass = characterClass;
        
        this.level = level;
        this.expMultiplier = expMultiplier;
        this.currentExp = currentExp;
        
        this.hp = hp;
        this.currentHp = currentHp;
        this.hp = hp;
        this.attack = attack;
        this.dexterity = dexterity;
        this.intelligence = intelligence;
        this.speed = speed;
        this.level = level;

        Debug.Log($"Stats from{characterName} copied.");
    }

    public float GainExp(int exp) {
        float gainedExp = exp * this.expMultiplier;
        
        this.currentExp += gainedExp;

        if (this.currentExp >= expToNextLevel) {
            LevelUp();
        }

        return gainedExp;
    }

    private void LevelUp() {
        this.level++;
        currentExp -= expToNextLevel;
        expToNextLevel = expToNextLevel * 1.5f;
    }
}
