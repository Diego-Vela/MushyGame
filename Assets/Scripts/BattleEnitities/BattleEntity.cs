using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    public Stats character;    
    // Character stats
    public string characterName = "Character"; // Holds character name
    public int hp; // Maximum health points
    public int currentHP;
    public int attack; // Attack power
    public int dexterity; // Dexterity (affects agility and chance to dodge)
    public int intelligence; // Intelligence (affects magic attack and healing)
    public int speed; // Speed (affects turn order in combat)
    public int currentSpeed; // Holds the current speed count

    void Start()
    {
        // Get Stats component attached to this GameObject
        character = GetComponent<Stats>();

        if (character != null)
        {
            // Assign Villager stats to BattleEntity stats
            characterName = character.name; // Assuming Villager class has a name field
            hp = character.baseHP;
            attack = character.baseAttack;
            dexterity = character.baseDexterity;
            intelligence = character.baseIntelligence;
            speed = character.baseSpeed;

            // Initialize current HP
            currentHP = hp;

            Debug.Log(characterName + " initialized with the following stats:");
            PrintStats();
        }
        else
        {
            Debug.LogError("Villager component not found on this GameObject.");
        }
    }

    // Method to deal damage to the character
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        Debug.Log(characterName + " took " + damage + " damage! Current HP: " + currentHP);

        if (currentHP == 0)
        {
            Die();
        }
    }

    // Method to heal the character
    public void Heal(int healAmount)
    {
        currentHP += healAmount;
        if (currentHP > hp)
        {
            currentHP = hp;
        }
        Debug.Log(characterName + " healed by " + healAmount + ". Current HP: " + currentHP);
    }

    // Method to print the character's stats
    public void PrintStats()
    {
        Debug.Log("HP: " + hp);
        Debug.Log("Attack: " + attack);
        Debug.Log("Dexterity: " + dexterity);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Speed: " + speed);
    }

    // Private method called when HP reaches zero
    private void Die()
    {
        Debug.Log(characterName + " has died.");
        // Add logic for what happens when a character dies
    }
}
