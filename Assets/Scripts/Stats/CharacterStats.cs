using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Character stats
    public string characterName = "Character"; // Holds character name
    public int maxHP; // Maximum health points
    public int currentHP; // Current health points
    public int attack; // Attack power
    public int dexterity; // Dexterity still working on how this will work
    public int intelligence; // Intelligence (affects magic attack and healing)
    public int speed; // Speed (affects turn order in combat)

    void Start()
    {
        // Initialize stats
        currentHP = maxHP;
        Debug.Log(characterName + "initialized with the following stats:"); //Change to character name later
        PrintStats();
    }

    // Method to deal damage to the character
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        Debug.Log("Character took " + damage + " damage! Current HP: " + currentHP);

        if (currentHP == 0)
        {
            Die();
        }
    }

    // Method to heal the character
    public void Heal(int healAmount)
    {
        currentHP += healAmount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        Debug.Log("Character healed by " + healAmount + ". Current HP: " + currentHP);
    }

    // Method to print the character's stats
    public void PrintStats()
    {
        Debug.Log("HP: " + currentHP + "/" + maxHP);
        Debug.Log("Attack: " + attack);
        Debug.Log("Dexterity: " + dexterity);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Speed: " + speed);
    }

    // Private method called when HP reaches zero
    private void Die()
    {
        Debug.Log("Character has died.");
        // Add logic for what happens when a characyer dies
    }
}
