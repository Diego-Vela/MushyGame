using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaterSlime : Stats
{
    public bool isBoss; // True if enemy is considered a boss
    
    // Enemy-specific constructor or method to set stats
    public WaterSlime()
    {
        // Set the enemy-specific stats
        characterName = "Water Slime: Hawk Tuah";
        characterClass = "Slime Boss";
        hp = 100;
        attack = 35;
        speed = 300;

        level = 5;
        friend = false;
        isBoss = true;

        // Print the enemy's stats
        PrintStats();
    }

    public WaterSlime(Texture2D image)
    {
        // Set the enemy-specific stats
        characterName = "Water Slime: Hawk Tuah";
        characterClass = "Slime Boss";
        hp = 150;
        attack = 35;
        speed = 300;

        level = 5;
        friend = false;
        isBoss = true;

        this.image = image;

        // Print the enemy's stats
        PrintStats();
    }
}