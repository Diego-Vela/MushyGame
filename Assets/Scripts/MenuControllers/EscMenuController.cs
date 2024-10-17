using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenuController : MonoBehaviour
{
    #region variables
    public GameObject escMenu; // The escape menu UI panel
    public GameObject buttons; // All buttons
    public GameObject musicManager; // Reference to the musicManager
    public GameObject volumeMenu; // Reference to the volumeSlider
    public Slider volumeSlider; // Reference to the slider
    public Player player; // Reference to player for saving
    private AudioSource music; // Reference to the audioSource component

    private bool isMenuActive;
    #endregion

    #region EscapeMenuPanel
    void Start()
    {
        ResetMenu();
        music = musicManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses the game and shows the escape menu
    public void PauseGame()
    {
        // Set time scale to 0 to pause everything
        Time.timeScale = 0;

        // Show the escape menu UI
        escMenu.SetActive(true);
        buttons.SetActive(true);

        // Ensure that the escape menu is on top and receives input
        Canvas escMenuCanvas = escMenu.GetComponent<Canvas>();
        if (escMenuCanvas != null)
        {
            escMenuCanvas.sortingOrder = 100;  // Set a high sorting order to appear on top
        }

        // Disable background UI interactions by making the escape menu block raycasts
        escMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;

        isMenuActive = true;
    }

    private void ResetMenu()
    {
        escMenu.SetActive(false);
        buttons.SetActive(false);
        volumeMenu.SetActive(false);
        isMenuActive = false;
        Time.timeScale = 1;
    }
    #endregion

    #region buttons
    // Resumes the game and hides the escape menu
    public void ResumeGame()
    {
        ResetMenu();
    }
    public void Save()
    {
        player.savePlayer();
    }

    public void AudioSettings()
    {
        buttons.SetActive(false);
        volumeMenu.SetActive(true);
        volumeSlider.value = music.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }

    public void Back()
    {
        buttons.SetActive(true);
        volumeMenu.SetActive(false);
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
        //Code for using unity editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    #endregion
}
