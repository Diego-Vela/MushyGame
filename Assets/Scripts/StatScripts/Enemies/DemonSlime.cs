using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DemonSlime : Stats
{
    public bool isBoss; // True if enemy is considered a boss

    // Constructor to set up DemonSlime-specific stats
    public DemonSlime()
    {
        characterName = "Demon Slime: Himothy";
        characterClass = "Demon Slime Boss";

        // Set the DemonSlime-specific stats
        hp = 100;
        attack = 15;
        speed = 115;
        level = 5;
        friend = false;
        isBoss = true;

        // Print the DemonSlime's stats
        PrintStats();
    }

    public DemonSlime(Texture2D image)
    {
        // Set the enemy-specific stats
        characterName = "Demon Slime: Himothy";
        characterClass = "Demon Slime Boss";
        hp = 280;
        attack = 45;
        speed = 150;

        level = 5;
        friend = false;
        isBoss = true;

        this.image = image;

        // Print the enemy's stats
        PrintStats();
    }
}
