using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleController : MonoBehaviour
{
    #region variables
    public List<BattleEntity> entities = new List<BattleEntity>(); // List of all entities in battle
    private const int speedThreshold = 10000; // Threshold for turn
    private bool actionChosen = false; // Flag to indicate if a player action was chosen

    // Counters for friendlies and enemies
    private int friendlies = 0;
    private int enemies = 0;

    public GameObject battleMenu; // UI for player input
    private int currentActionKey = -1; // Stores the action key (0 for attack, 1 for heal, 2 for run)
    public BattleEntity enemy; // Reference to the target 
    public BattleEntity player; // Reference to player

    #endregion

    #region methods
    
    private void OnEnable()
    {
        // Event from PlayerMenu, subscribe to event
        PlayerMenu.OnActionChosen += HandleActionChosen;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        PlayerMenu.OnActionChosen -= HandleActionChosen;
    }

    // Method to handle the action chosen event, receives the action key from PlayerMenu
    private void HandleActionChosen(int actionKey)
    {
        currentActionKey = actionKey;
        actionChosen = true; // Set the flag to continue the coroutine
    }

    void Start()
    {
        // Find and add all BattleEntity components in the scene to the list
        entities.AddRange(FindObjectsOfType<BattleEntity>());

        InitializeBattle();
        StartCoroutine(BeginBattle());
    }

    IEnumerator BeginBattle()
    {
        // Continue battle while there are still friendlies and enemies
        while (friendlies > 0 && enemies > 0)
        {
            // Calculate speed and find ready entities
            List<BattleEntity> readyEntities = GetReadyEntities();

            // Sort the ready entities by overflow
            SortEntitiesByOverflow(readyEntities);

            // Process turns in order
            foreach (BattleEntity entity in readyEntities)
            {
                Debug.Log(entity.characterName + " takes their turn!");

                yield return StartCoroutine(TakeTurn(entity));

                // Ensure turn completion
                Debug.Log($"{entity.characterName} has finished their turn.");

                entity.currentSpeed -= speedThreshold; // Reset speed with overflow logic
            }

            // Clear the ready entities list for the next round
            readyEntities.Clear();

            Debug.Log("Finished an iteration, clearing queue");
        }

        // End the battle and determine the outcome
        EndBattle();
    }

    // Initialize the battle and count the entities
    void InitializeBattle()
    {
        friendlies = 0;
        enemies = 0;

        foreach (BattleEntity entity in entities)
        {
            if (entity.isFriendly)
            {
                friendlies++;
            }
            else
            {
                enemies++;
            }
        }

        Debug.Log($"Battle initialized with {friendlies} friendlies and {enemies} enemies. Total: {friendlies+enemies}");
    }

    // Get a list of entities that are ready to take their turn (speed exceeds threshold)
    List<BattleEntity> GetReadyEntities()
    {
        List<BattleEntity> readyEntities = new List<BattleEntity>();
        bool ready = false;

        while (!ready)
        {
            // Calculate speed and check for overflow
            foreach (BattleEntity entity in entities)
            {
                entity.currentSpeed += entity.speed;

                if (entity.currentSpeed >= speedThreshold)
                {
                    ready = true;
                    readyEntities.Add(entity);
                }
            }
        }
        return readyEntities;
    }

    // Sort entities by how much their speed exceeds the threshold (from most to least overflow)
    void SortEntitiesByOverflow(List<BattleEntity> readyEntities)
    {
        readyEntities.Sort((a, b) =>
            (b.currentSpeed - speedThreshold).CompareTo(a.currentSpeed - speedThreshold));
    }

    IEnumerator TakeTurn(BattleEntity entity)
    {
        if (entity.isFriendly)
        {
            // Unhide battle menu and wait for player action
            battleMenu.SetActive(true);
            actionChosen = false; // Reset action flag for player's turn
            currentActionKey = -1; // Reset action key

            // Wait for the player to choose an action
            while (!actionChosen)
            {
                yield return null; // Pause until an action is chosen
            }

            // Hide battle menu after action is taken
            battleMenu.SetActive(false);

            // Handle the chosen action based on the actionKey
            HandlePlayerAction(player);
        }
        else
        {
            // Enemy attacks automatically
            Debug.Log($"{entity.characterName} attacks!");
            player.TakeDamage(entity.attack); // Attack logic for enemies
        }

        // Check if the entity has been defeated
        if (entity.isDead)
        {
            RemoveEntityFromBattle(entity);
        }
    }

    // Method to handle player action based on the action key
    private void HandlePlayerAction(BattleEntity entity)
    {
        switch (currentActionKey)
        {
            case 0: // Attack
                Debug.Log("Player attacks!");
                enemy.TakeDamage(entity.attack); 
                break;

            case 1: // Heal
                Debug.Log("Player heals!");
                entity.Heal(entity.intelligence*2);
                break;

            case 2: // Run
                Debug.Log("Player runs away!");
                SceneManager.LoadScene("HomeTown"); // Load the HomeTown scene
                break;

            default:
                Debug.LogError("Invalid action key!");
                break;
        }
        actionChosen = true;
    }

    // Remove an entity from the battle and update the count
    void RemoveEntityFromBattle(BattleEntity entity)
    {
        entities.Remove(entity);

        if (entity.isFriendly)
        {
            friendlies--;
        }
        else
        {
            enemies--;
        }

        Debug.Log($"{entity.characterName} was defeated. Remaining friendlies: {friendlies}, Remaining enemies: {enemies}");
    }

    // End the battle and declare win/loss
    void EndBattle()
    {
        if (enemies <= 0)
        {
            Debug.Log("You won the battle!");
        }
        else if (friendlies <= 0)
        {
            Debug.Log("You lost the battle...");
        }
    }
    #endregion
}
