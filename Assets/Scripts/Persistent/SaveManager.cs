using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private SaveData data;
    public GameState gamestate;

    private bool isNewGame = false; // Flag to indicate if it's a new game

    private void Awake()
    {
        // Ensure this object persists across scene loads
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetUpData(SaveData data)
    {
        this.data = data; 

        // Load game state and party data first
        LoadParty();
        LoadGameState();

        // Load the scene, then set up player data after the scene has fully loaded
        LoadScene();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void SetIsNewGame(bool newGame)
    {
        isNewGame = newGame;
    }

    public bool IsNewGame()
    {
        return isNewGame;
    }

    private void LoadGameState()
    {
        gamestate.charlotte = data.charlotte;
        gamestate.gunther = data.gunther;
        gamestate.daisy = data.daisy;
        
        gamestate.waterDefeated = data.waterDefeated;
        gamestate.earthDefeated = data.earthDefeated;
        gamestate.demonDefeated = data.demonDefeated;
    }

    private void LoadParty()
    {
        PartyCreator partyCreator = GameObject.FindGameObjectWithTag("PartyCreator").GetComponent<PartyCreator>();
        foreach (string member in data.party)
        {
            partyCreator.AddCharacterByName(member);
        }    
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(data.scene);
    }

    private void LoadPlayer()
    {
        // Use a coroutine to ensure the player is found even if there’s a slight delay
        StartCoroutine(SetPlayerPositionWhenAvailable());
    }

    private System.Collections.IEnumerator SetPlayerPositionWhenAvailable()
    {
        // Wait until the player object exists in the scene
        GameObject playerObject;
        while ((playerObject = GameObject.FindGameObjectWithTag("Player")) == null)
        {
            yield return null;
        }

        // Set player position once the player object is found
        Player player = playerObject.GetComponent<Player>();
        player.SetPosition(data.position[0], data.position[1]);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the event to avoid multiple calls
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Load player data after the scene has loaded
        LoadPlayer();
    }
}
