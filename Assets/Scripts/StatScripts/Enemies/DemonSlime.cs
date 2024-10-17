using UnityEngine;

public class DemonSlime : Stats
{
    public bool isBoss; // True if enemy is considered a boss
    
    // Enemy-specific constructor or method to set stats
    private void Start()
    {
        // Set the enemy-specific stats
        characterName = "DemonSlime";
        baseHP = 100;
        baseAttack = 15;
        baseSpeed = 85;

        level = 5;
        friend = false;
        isBoss = true;

        // Print the enemy's stats
        PrintStats();
    }
}