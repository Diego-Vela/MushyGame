using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]   
    public static VolumeControl Instance;
    
    public float volume = .5f;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates if they exist
        }
    }
}
