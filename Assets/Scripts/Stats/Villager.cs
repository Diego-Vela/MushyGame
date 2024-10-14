using UnityEngine;

public class Villager : CharacterStats
{
    public float baseExp = 100; // Base exp per level
    private int level; // Current character level
    private float expMultiplier = 1.5; // expMultiplier per level
    void Awake()
    {
        // Set default values for a villager
        maxHP = 50;           // Villagers usually have lower HP
        attack = 5;           // Villager's physical attack is weak
        dexterity = 10;       // Dexterity is average
        intelligence = 8;     // Villagers are not highly intelligent
        speed = 5;            // Speed is slow compared to combat units

        // Initialize current HP
        currentHP = maxHP;
    }

    void Start()
    {
        // Optionally print stats to check if they are set correctly
        Debug.Log("Villager initialized with the following stats:");
        PrintStats();
    }
}
