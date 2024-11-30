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
    public bool friend;
    public int level;

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

    public virtual void SetName(string name)
    {
        characterName = name;
    }

    public virtual void SetImage(Texture2D image)
    {
        this.image = image;
    }
}
