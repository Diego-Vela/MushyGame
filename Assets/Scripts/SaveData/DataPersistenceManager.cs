using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    private PlayerData playerData;
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

    public void SetPlayerData(PlayerData data)
    {
        playerData = data;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public void SetIsNewGame(bool newGame)
    {
        isNewGame = newGame;
    }

    public bool IsNewGame()
    {
        return isNewGame;
    }
}
