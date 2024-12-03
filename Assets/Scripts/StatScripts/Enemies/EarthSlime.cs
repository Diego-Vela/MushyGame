using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EarthSlime : Stats
{
    public bool isBoss; // True if enemy is considered a boss
    
    // Enemy-specific constructor or method to set stats
    public EarthSlime()
    {
        // Set the enemy-specific stats
        characterName = "Earth Slime: Rock the Dwayne Johnson";
        characterClass = "Slime Boss";
        hp = 500;
        attack = 40;
        speed = 75;

        level = 5;
        friend = false;
        isBoss = true;

        // Print the enemy's stats
        PrintStats();
    }

    public EarthSlime(Texture2D image)
    {
        // Set the enemy-specific stats
        characterName = "Earth Slime: Rock the Dwayne Johnson";
        characterClass = "Slime Boss";
        hp = 300;
        attack = 40;
        speed = 70;

        level = 5;
        friend = false;
        isBoss = true;

        this.image = image;

        // Print the enemy's stats
        PrintStats();
    }
}