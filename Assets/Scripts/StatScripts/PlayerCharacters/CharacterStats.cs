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

    public CharacterStats(Texture2D image, CharacterSaveData character) {
        InitializeStats(image, character);
        this.friend = true;
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

        this.hp = 130;
        this.currentHp = this.hp;

        this.attack = 20;
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

    public void InitializeStats(Texture2D image, CharacterSaveData character) {
        
        this.characterName = character.characterName;
        this.characterClass = character.characterClass;
        
        this.level = character.level;
        this.expMultiplier = character.expMultiplier;
        this.expToNextLevel = character.expToNextLevel;
        this.currentExp = character.currentExp;
        
        this.hp = character.hp;
        this.currentHp = character.currentHp;
        this.attack = character.attack;
        this.dexterity = character.dexterity;
        this.intelligence = character.intelligence;
        this.speed = character.speed;

        Debug.Log($"Stats for {characterName} copied.");

        this.image = image;
    }

    public int GainExp(float exp) {
        float gainedExp = exp * this.expMultiplier;
        
        this.currentExp += gainedExp;

        if (this.currentExp >= expToNextLevel) {
            LevelUp();
        }

        return (int)gainedExp;
    }

    protected virtual void LevelUp() {
        this.level++;
        currentExp -= expToNextLevel;
        expToNextLevel = expToNextLevel * 1.5f;

        // Increase Stats
        this.hp += 15;
        this.currentHp = this.hp;
        this.attack += 5;
        //this.dexterity += 3;
        this.intelligence += 2;
    }
}
