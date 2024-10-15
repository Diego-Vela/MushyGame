using UnityEngine;

public class Stats : MonoBehaviour
{
    // Character stats
    public string characterName = "Character"; // Holds character name
    public int baseHP; // Maximum health points
    public int baseAttack; // Attack power
    public int baseDexterity; // Dexterity still working on how this will work
    public int baseIntelligence; // Intelligence (affects magic attack and healing)
    public int baseSpeed; // Speed (affects turn order in combat)



    // Method to print the character's stats
    public void PrintStats()
    {
        Debug.Log("HP: " + baseHP);
        Debug.Log("Attack: " + baseAttack);
        Debug.Log("Dexterity: " + baseDexterity);
        Debug.Log("Intelligence: " + baseIntelligence);
        Debug.Log("Speed: " + baseSpeed);
    }
}
