using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    // Singleton instance
    public static EnemyInfo Instance;

    // Enemy properties
    public Stats enemyEntity;        // Enemy stats (Stats component)

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists
        }
    }
}

