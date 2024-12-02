using UnityEngine;

public class BrightnessCanvas : MonoBehaviour
{
    public static BrightnessCanvas Instance;

    private Color color;

    private void Awake()
    {
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
    void LoadBrightness() {
        
    }
}
