using UnityEngine;

public class Stats : MonoBehaviour
{
    // Character stats
    public string characterName; // Holds character name
    public int baseHP; // Maximum health points
    public int baseAttack; // Attack power
    public int baseDexterity; // Dexterity still working on how this will work
    public int baseIntelligence; // Intelligence (affects magic attack and healing)
    public int baseSpeed; // Speed (affects turn order in combat)
    public int level; // Level of characters
    public bool friend; // Differentiate between enemies and companions



    // Method to print the character's stats
    public void PrintStats()
    {
        Debug.Log("Stats for " + characterName + "\nHP: " + baseHP
        + "\nAttack: " + baseAttack + "\nDexterity: " + baseDexterity 
        + "\nIntelligence: " + baseIntelligence + "\nSpeed: " + baseSpeed 
        + "\nLvel: " + level);
    }
}
