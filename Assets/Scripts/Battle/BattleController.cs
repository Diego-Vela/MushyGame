using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class BattleController : MonoBehaviour
{
    #region variables
    private const int speedThreshold = 10000; // Threshold for turn
    private bool actionChosen = false; // Flag to indicate if a player action was chosen
    private int currentActionKey = -1; // Stores the action key (0 for attack, 1 for heal, 2 for run)

    // Counters for friendlies and enemies
    private int friendlies = 0;
    private int enemies = 0;

    public List<BattleEntity> entities = new List<BattleEntity>(); // List of all entities in battle
    public List<BattleEntity> party = new List<BattleEntity>(); // List of all allies for targeting purposes

    public GameObject battleMenu; // UI for player input
    public GameObject loseMenu; // UI for loseMenu
    public GameObject actions; // Reference to turn off buttons when not player turn
    private SceneTransitioner sceneTransitioner; // return to previous scene.
    public MusicManager musicManager; // Reference to the music manager
    public BattleEntity enemy; // Reference to the target 
    public EventTextBoxController log; // Reference to text box

    private List<BattleEntity> readyEntities = new List<BattleEntity>();
    private float expGain = 15;

    #endregion

    #region methods

    // Method to handle the action chosen event, receives the action key from PlayerMenu
    public void ActionChosen(int actionKey)
    {
        currentActionKey = actionKey;
        actionChosen = true; // Set the flag to continue the coroutine
    }

    private void Start()
    {
        // Find GameObjects
        sceneTransitioner = GameObject.FindGameObjectWithTag("SceneTransitioner").GetComponent<SceneTransitioner>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();

        // winMenu.SetActive(false);
        actions.SetActive(false);

        // Find and add all BattleEntity components in the scene to the list
        entities.AddRange(FindObjectsByType<BattleEntity>(FindObjectsSortMode.None));
        party.AddRange(FindObjectsByType<BattleEntity>(FindObjectsSortMode.None).Where(member => member.isFriendly == true));

        InitializeBattle();
        StartCoroutine(BeginBattle());
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

    IEnumerator BeginBattle()
    {
        yield return StartCoroutine(log.LogEvent
            ($"Battle Begin!"));
        // Continue battle while there are still friendlies and enemies
        while (friendlies > 0 && enemies > 0)
        {
            // Calculate speed and find ready entities
            readyEntities = GetReadyEntities();

            // Sort the ready entities by overflow
            SortEntitiesByOverflow(readyEntities);

            // Process turns in order
            foreach (BattleEntity entity in readyEntities)
            {
                if (entity.isDead) {
                    continue;
                } 
                yield return StartCoroutine(TakeTurn(entity));
                entity.currentSpeed -= speedThreshold; // Reset speed with overflow logic
            }
        }
    }

    // Get a list of entities that are ready to take their turn
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
            yield return StartCoroutine(log.LogActionEvent
                ($"{entity.characterName} moves."));
            actions.SetActive(true);
            entity.WaitForAction();
            yield return new WaitUntil(() => actionChosen == true);
            entity.EndAction();
            actions.SetActive(false);
            // Handle the chosen action based on the actionKey
            yield return StartCoroutine(HandlePlayerAction(entity));
        }
        else
        {
            // Enemy attacks twice
            BattleEntity target1 = EntityAI(party);

            yield return StartCoroutine(log.LogEvent(
                $"{entity.characterName} attacks {target1.characterName} for {entity.attack} damage!"));
            target1.TakeDamage(entity.attack);
            yield return StartCoroutine(CheckDeath(target1));

            BattleEntity target2 = EntityAI(party);

            yield return StartCoroutine(log.LogEvent(
                $"{entity.characterName} attacks {target2.characterName} for {entity.attack} damage!"));
            target2.TakeDamage(entity.attack);
            yield return StartCoroutine(CheckDeath(target2));
        }
    }

    // Method to handle player action based on the action key
    private IEnumerator HandlePlayerAction(BattleEntity entity)
    {
        switch (currentActionKey)
        {
            case 0: // Attack
                yield return StartCoroutine(log.LogEvent(
                    $"{entity.characterName} attacks {enemy.characterName} for {entity.attack} damage!"));
                enemy.TakeDamage(entity.attack);
                yield return StartCoroutine(CheckDeath(enemy)); 
                break;

            case 1: // Heal
                yield return StartCoroutine(log.LogEvent(
                    $"{entity.characterName} heals for {entity.intelligence*3} hp!"));
                entity.Heal(entity.intelligence*3);
                break;

            case 2: // Run
                yield return StartCoroutine(log.LogEvent(
                    $"{entity.characterName}'s party ran away..."));
                sceneTransitioner.ReturnToSavedPosition(false);
                yield return new WaitForSeconds(1);
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
        CountAndRemoveEntities(entity);
        CheckEndBattle();
    }

    //Checks if entity died
    IEnumerator CheckDeath(BattleEntity entity)
    {
        if (entity.isDead)
        {
            yield return StartCoroutine(log.LogEvent(
                $"{entity.characterName} has fainted..."));
            RemoveEntityFromBattle(entity);
        }
    }

    // Checks if the battle is won
    void CheckEndBattle() 
    {
        if (friendlies <= 0 || enemies <= 0) 
        {
            EndBattle();
        }
    }

    void CountAndRemoveEntities(BattleEntity entity) 
    {
        entities.Remove(entity);
        if (entity.isFriendly)
        {
            friendlies--;
            party.Remove(entity);
        }
        else
            enemies--;
        Debug.Log($"Remaining friendlies: {friendlies}, Remaining enemies: {enemies}");
    }

    // End the battle and declare win/loss
    void EndBattle()
    {
        StopAllCoroutines();
        if (enemies > 0)
            StartCoroutine(loseGame());
        else
            StartCoroutine(winGame());
    }

    IEnumerator winGame() 
    {
        Debug.Log("You won the battle!");
        yield return StartCoroutine(log.LogEvent($"You've won this battle!"));
        yield return StartCoroutine(HandleExpGain());
        sceneTransitioner.ReturnToSavedPosition(true);
    }
    
    IEnumerator loseGame() 
    {
        Debug.Log("You lost the battle!");
        yield return StartCoroutine(log.LogEvent($"You've lost this battle!"));
        musicManager.PlayLoss();
        loseMenu.SetActive(true);
    }

    IEnumerator HandleExpGain() {
        string results = "";
        foreach(BattleEntity member in party) {
            if (member.stats is CharacterStats characterStats) {
                results += $"{characterStats.characterName} gained {characterStats.GainExp(expGain)} exp.\n";
            }
        }

        yield return StartCoroutine(log.LogEvent($"{results}"));
    }

    #endregion




    public BattleEntity EntityAI(List<BattleEntity> targets)
    {
        return GetEnemyTarget(targets);
    }

    BattleEntity GetEnemyTarget(List<BattleEntity> targets)
    {
        if (Random.Range(0f, 1f) <= 0.55f)
        {
            return GetEntityWithLowestHp(targets);
        }
        else
        {
            return GetRandomEntity(targets);
        }
    }
    
    BattleEntity GetEntityWithLowestHp(List<BattleEntity> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            Debug.LogWarning("Targets is not correct");
            return null;
        }

        BattleEntity lowestHpEntity = targets[0];

        foreach (BattleEntity target in targets)
        {
            if (target.currentHP/target.hp < lowestHpEntity.currentHP/lowestHpEntity.hp)
            {
                lowestHpEntity = target;
            }
        }

        return lowestHpEntity;
    }

    BattleEntity GetRandomEntity(List<BattleEntity> targets) 
    {
        if (targets == null || targets.Count == 0)
        {
            Debug.LogWarning("Targets list is empty or null");
            return null;
        }

        int randomIndex = Random.Range(0, targets.Count);
        return targets[randomIndex];
    }
}
