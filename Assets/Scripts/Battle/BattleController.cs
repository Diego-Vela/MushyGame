using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    #endregion

    #region methods
    void Start()
    {
        // Find and add all BattleEntity components in the scene to the list
        entities.AddRange(FindObjectsOfType<BattleEntity>());

        InitializeBattle();
        StartCoroutine(BeginBattle());
    }

    // Main battle loop
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
                yield return StartCoroutine(TakeTurn(entity));
                entity.currentSpeed -= speedThreshold; // Reset speed with overflow logic
            }
        }

        // End the battle and determine the outcome
        EndBattle();
    }

    // Initialize the battle and count the entities
    void InitializeBattle()
    {
        // Initialize entity counts
        friendlies = 0;
        enemies = 0;

        // Count friendlies and enemies
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
        List<BattleEntity> readyEntities = new List<BattleEntity>(); // List that tracks how many entities are ready for a turn.
        bool ready = false; // False while all currentSpeed is under 10000

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

    // Coroutine to handle the entity's turn logic
    IEnumerator TakeTurn(BattleEntity entity)
    {
        Debug.Log(entity.characterName + " takes their turn!");

        if (entity.isFriendly)
        {
            // Unhide battle menu and wait for player action
            battleMenu.SetActive(true);
            actionChosen = false; // Reset action flag

            // Wait for the player to choose an action
            while (!actionChosen)
            {
                yield return null; // Pause until an action is chosen
            }

            // Hide battle menu after action is taken
            battleMenu.SetActive(false);

            // Perform the chosen action (for now, just damage the enemy)
            // You could extend this to include more options (heal, run, etc.)
            entity.TakeDamage(entity.attack);
        }
        else
        {
            // Enemy attacks automatically
            Debug.Log(entity.characterName + " attacks!");
            entity.TakeDamage(entity.attack); // Attack logic for enemies
        }

        // If the entity is defeated, remove it from the battle
        if (entity.isDead)
        {
            RemoveEntityFromBattle(entity);
        }
    }

    // Method to be called when an action is chosen (linked to attack/heal/run buttons)
    public void ActionChosen()
    {
        actionChosen = true; // Set the flag to continue the coroutine
    }

    // Remove an entity from the battle and update the count
    void RemoveEntityFromBattle(BattleEntity entity)
    {
        entities.Remove(entity);  // Remove the entity from the list

        // Update the global counts
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
