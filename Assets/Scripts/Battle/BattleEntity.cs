using UnityEngine;
using UnityEngine.UI;

public class BattleEntity : MonoBehaviour
{
    public Stats character;    
    // Character stats
    public string characterName; // Holds character name
    public int hp; // Maximum health points
    public int currentHP;
    public int attack; // Attack power
    public int dexterity; // Dexterity
    public int intelligence; // Intelligence (affects magic attack and healing)
    public int speed; // Speed (affects turn order in combat)
    public int currentSpeed; // Holds the current speed count
    public bool isDead; // Bool that checks if character is dead 
    public bool isFriendly; // Bool that checks if character is friendly

    private Slider healthSlider; // Health Slider of entity
    private Animator animator; // Animation

    void Start()
    {
        initializeStats();
        initializeHealthSlider();
        initializeAnimation();
    }

    // Method to initialize character stats
    private void initializeStats() {
        
        // Get Stats component attached to this GameObject
        character = GetComponent<Stats>();
        // Check if for errors
        if (character != null)
        {
            // Assign stats to BattleEntity stats
            characterName = character.characterName;
            hp = character.baseHP;
            attack = character.baseAttack;
            dexterity = character.baseDexterity;
            intelligence = character.baseIntelligence;
            speed = character.baseSpeed;
            // Initialize current values
            currentHP = hp;
            currentSpeed = 0;
            // Bool values
            isFriendly = character.friend;
            if (currentHP > 0)
                isDead = false;
            else 
                isDead = true;
            Debug.Log(characterName + " is now a battle entity");
        }
        else
            Debug.LogError("Stats component not found on this GameObject.");
    }

    //Method to set HealthSlider
    private void initializeHealthSlider() {
        if (isFriendly)
        {
            GameObject HealthObject = GameObject.FindWithTag("Health");
            if (HealthObject != null)

                healthSlider = HealthObject.GetComponent<Slider>();
            else
                Debug.LogError("Health GameObject not found or does not have a Slider!");
        }
        else 
        {
            GameObject bossHealthObject = GameObject.FindWithTag("EnemyBossHealth");
            if (bossHealthObject != null)

                healthSlider = bossHealthObject.GetComponent<Slider>();
            else
                Debug.LogError("EnemyBossHealth GameObject not found or does not have a Slider!");
        }
    }
    
    private void initializeAnimation()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isTurn", false);
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

        UpdateHealthBar();
        checkDeath();
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
        UpdateHealthBar();
    }

    // Private method called when HP reaches zero
    private void Die()
    {
        Debug.Log(characterName + " has died.");
        isDead = true;
    }

    void checkDeath() {
        if (currentHP == 0)
            Die();
    }

    //Private method to update health bar
    void UpdateHealthBar()
    {
        if(healthSlider != null)
        {
            healthSlider.value = (float)currentHP/hp;
            Debug.Log($"Health value of {characterName} at {healthSlider.value}");
        }
    }

    public void WaitForAction()
    {
        animator.SetBool("isTurn", true);
        animator.Play("PlayerTurn");
    }
    
    public void EndAction()
    {
        animator.SetBool("isTurn", false);
        animator.Play("Empty");
    }

    public void FriendlyAttack()
    {
        animator.Play("PlayerAttack");
    }

    public void EnemyAttack()
    {
        animator.Play("DemonSlimeAttack");
    }
}
