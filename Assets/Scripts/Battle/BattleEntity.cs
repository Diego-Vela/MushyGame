using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleEntity : MonoBehaviour
{   
    // Character stats
    public string characterName; // Holds character name
    public float hp; // Maximum health points
    public float currentHP;
    public float attack; // Attack power
    public float dexterity; // Dexterity
    public float intelligence; // Intelligence (affects magic attack and healing)
    public float speed; // Speed (affects turn order in combat)
    public float currentSpeed; // Holds the current speed count
    public bool isDead; // Bool that checks if character is dead 
    public GameObject HealthObject;
    public bool isFriendly; // Bool that checks if character is friendly

    private Slider healthSlider; // Health Slider of entity
    private Animator animator; // Animation

    public void CreateEntity(Stats character)
    {
        InitializeStats(character);
        InitializeHealthSlider();
        InitializeAnimation();
    }

    // Method to initialize character stats
    private void InitializeStats(Stats character) {
        // Check if for errors
        if (character != null)
        {
            // Assign stats to BattleEntity stats
            characterName = character.characterName;
            hp = character.hp;
            attack = character.attack;
            dexterity = character.dexterity;
            intelligence = character.intelligence;
            speed = character.speed;
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
            // Image
            GetComponent<RawImage>().texture = character.image;
        }
        else
            Debug.LogError("Stats component not found on this GameObject.");
    }

    //Method to set HealthSlider
    private void InitializeHealthSlider() 
    {
        if (HealthObject != null) 
        {
            healthSlider = HealthObject.GetComponent<Slider>();
            if (healthSlider != null)
                Debug.Log("HealthSlider not succeswsful");
        }
        else
            Debug.LogError("Health GameObject not found or does not have a Slider!");

        if (!isFriendly)
        {
            SetUpHealthName();
        }
    }
    
    private void InitializeAnimation()
    {
        if (isFriendly)
        {
            animator = GetComponent<Animator>();
            animator.SetBool("isTurn", false);
        }

    }
    
    // Method to deal damage to the character
    public void TakeDamage(float damage)
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
    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        if (currentHP > hp)
        {
            currentHP = hp;
        }
        //Debug.Log(characterName + " healed by " + healAmount + ". Current HP: " + currentHP);
        UpdateHealthBar();
    }

    // Private method called when HP reaches zero
    private void Die()
    {
        // Debug.Log(characterName + " has died.");
        isDead = true;
    }

    void checkDeath() {
        if (currentHP == 0)
            Die();
    }

    //Private method to update health bar
    void UpdateHealthBar()
    {
        //Debug.Log("Trying to update health");
        if(healthSlider != null)
        {
            healthSlider.value = (float)currentHP/hp;
            Debug.Log($"Health value of {characterName} at {currentHP}");
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

    private void SetUpHealthName()
    {
        TextMeshProUGUI childText = GameObject.FindGameObjectWithTag("EnemyBossHealth").GetComponent<TextMeshProUGUI>();
        if (childText == null)
            Debug.Log("Not found");
        
        childText.text = characterName;
    }
}
