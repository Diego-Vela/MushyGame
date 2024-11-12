using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Stats
{
    public string characterName;
    public string characterClass;
    public Texture2D image;

    public float hp;
    public float attack;
    public float dexterity;
    public float intelligence;
    public float speed;
    
    public int level;
    public bool friend;

    // Method to print stats to the console
    public virtual void PrintStats()
    {
        string stats = $"{characterName} Stats:\n" +
                       $"HP: {hp}\n" +
                       $"Attack: {attack}\n" +
                       $"Dexterity: {dexterity}\n" +
                       $"Intelligence: {intelligence}\n" +
                       $"Speed: {speed}\n" +
                       $"Level: {level}";

        Debug.Log(stats);
    }

    // Virtual method to set the current instance's values to those of another Stats instance
    public virtual void SetValuesFrom(Stats other)
    {
        if (other == null) return;

        this.hp = other.hp;
        this.attack = other.attack;
        this.dexterity = other.dexterity;
        this.intelligence = other.intelligence;
        this.speed = other.speed;
        this.level = other.level;

        Debug.Log($"Stats from{other.characterName} copied.");
    }

    public virtual void SetName(string name)
    {
        characterName = name;
    }

    public virtual void SetImage(Texture2D image)
    {
        this.image = image;
    }
}
