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

    // Method to handle the action chosen event, receives the action key from PlayerMenu
    public void ActionChosen(int actionKey)
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
                yield return StartCoroutine(TakeTurn(entity));
                entity.currentSpeed -= speedThreshold; // Reset speed with overflow logic
            }
        }

        // Unreachable
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
        Debug.Log(entity.characterName + " takes their turn!");
        if (entity.isFriendly)
        {
            yield return new WaitUntil(() => actionChosen == true);

            // Handle the chosen action based on the actionKey
            HandlePlayerAction(player);
        }
        else
        {
            // Enemy attacks automatically
            Debug.Log($"{entity.characterName} attacks!");
            player.TakeDamage(entity.attack); // Attack logic for enemies
        }
        Debug.Log(entity.characterName + " ends their turn!");
        yield return new WaitForSeconds(3);
    }

    // Method to handle player action based on the action key
    private void HandlePlayerAction(BattleEntity entity)
    {
        switch (currentActionKey)
        {
            case 0: // Attack
                enemy.TakeDamage(entity.attack);
                checkDeath(enemy); 
                break;

            case 1: // Heal
                entity.Heal(entity.intelligence*2);
                break;

            case 2: // Run
                SceneManager.LoadScene("HomeTown"); // Load the HomeTown scene
                break;

            default:
                Debug.LogError("Invalid action key!");
                break;
        }

        resetAction();
    }

    void resetAction() 
    {
        actionChosen = false;
        currentActionKey = -1;
    }

    // Remove an entity from the battle and update the count
    void RemoveEntityFromBattle(BattleEntity entity)
    {
        entities.Remove(entity);
        countEntities(entity);
        checkEndBattle();
    }

    //Checks if entity died
    void checkDeath(BattleEntity entity)
    {
        if (entity.isDead)
        {
            RemoveEntityFromBattle(entity);
        }
    }

    // Checks if the battle is won
    void checkEndBattle() 
    {
        if (friendlies <= 0 || enemies <= 0) 
        {
            EndBattle();
        }
    }

    void countEntities(BattleEntity entity) 
    {
        if (entity.isFriendly)
            friendlies--;
        else
            enemies--;
        Debug.Log($"Remaining friendlies: {friendlies}, Remaining enemies: {enemies}");
    }

    // End the battle and declare win/loss
    void EndBattle()
    {
        if (friendlies <= 0)
            loseGame();
        else
            winGame();
    }

    void winGame() 
    {
        Debug.Log("You won the battle!");
        // Win Screen Here to return to title
        SceneManager.LoadScene("HomeTown"); // Load the HomeTown scene
    }
    
    void loseGame() 
    {
        Debug.Log("You lost the battle!");
        // Lose Screen Here to return to title
        SceneManager.LoadScene("HomeTown"); // Load the HomeTown scene
    }
    #endregion
}
