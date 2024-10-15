using UnityEngine;

public class Villager : Stats
{
    public float baseExp = 100; // Base exp per level
    private float expMultiplier = 1.5f; // expMultiplier per level
    void Awake()
    {
        // Set default values for a villager
        baseHP = 100; // Base at 100
        baseAttack = 50; // Base at 5
        baseDexterity = 10; // Base at 5
        baseIntelligence = 10; // Base at 5
        baseSpeed = 92; // Base at 100

        level = 1;
        friend = true;

        characterName = "Diego";
    }

    void Start()
    {
        // Optionally print stats to check if they are set correctly
        Debug.Log("Villager initialized:");
        PrintStats();
    }
}
