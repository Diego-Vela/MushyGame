using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner instance;

    public Vector2 playerPosition; // Stores the player's x, y position
    public string sceneName;       // Stores the current scene name
    public BattleResults battleResult;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates if they exist
        }
    }

    // Method to save the current scene and player position
    public void SavePosition(GameObject player)
    {
        sceneName = SceneManager.GetActiveScene().name; // Save the current scene name
        playerPosition = player.transform.position;      // Save the player's position
    }

    // Method to load the saved scene and position
    public void ReturnToSavedPosition(bool battleWon)
    {
        StartCoroutine(LoadScene(battleWon));
    }

    private IEnumerator LoadScene(bool battleWon)
    {
        // Load the saved scene first to transform player position after.
        yield return SceneManager.LoadSceneAsync(sceneName); 
        
        // Load the player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) {
            player.transform.position = playerPosition;
        } else {
            Debug.LogWarning("Where did the player go?");
        }

        // Battle Results logic
        if (battleWon)
            battleResult.BattleWon();
    }

    public void TransitionScene(string targetScene, Vector2 position)
    {
        StartCoroutine(LoadScene(targetScene, position));
    }

    private IEnumerator LoadScene(string targetScene, Vector2 position)
    {
        // Load the saved scene first to transform player position after.
        yield return SceneManager.LoadSceneAsync(targetScene); 
        
        // Load the player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) {
            player.transform.position = position;
        } else {
            Debug.LogWarning("Where did the player go?");
        }
    }

}
