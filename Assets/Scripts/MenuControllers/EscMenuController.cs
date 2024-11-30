using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenuController : MonoBehaviour
{
    #region variables
    public GameObject escMenu; // The escape menu UI panel
    public GameObject buttons; // All buttons
    public GameObject partyMenu; // Party Menu Controller
    private Player player; // Reference to player for saving

    private GameObject musicManager; // Reference to the musicManager
    public GameObject volumeMenu; // Reference to the volumeSlider
    public Slider volumeSlider; // Reference to the slider
    private AudioSource music; // Reference to the audioSource component

    private bool isMenuActive;
    #endregion

    #region EscapeMenuPanel
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        music = musicManager.GetComponent<AudioSource>();

        Debug.Log("Initializing EscapeMenuPanel");

        escMenu.SetActive(false);
        partyMenu.SetActive(false);
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
            {
                Debug.Log("Resuming Game");
                ResumeGame();
            }
            else
            {
                Debug.Log("Pausing Game");
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
        escMenu.SetActive(true);
        buttons.SetActive(true);
        partyMenu.SetActive(false);
        volumeMenu.SetActive(false);
    }
    #endregion

    #region buttons
    // Resumes the game and hides the escape menu
    public void ResumeGame()
    {
        ResetMenu();
        escMenu.SetActive(false);
        Time.timeScale = 1;
        isMenuActive = false;
    }
    public void Save()
    {
        player.Save();
    }

    public void AudioSettings()
    {
        //buttons.SetActive(false);
        volumeMenu.SetActive(true);
        volumeSlider.value = music.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

    }

    public void SetVolume(float volume) {
        music.volume = volume;
    }

    public void Back() {
        ResetMenu();
    }

    public void ReturnToTitle() {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame() {
        Application.Quit();
        //Code for using unity editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void PartyMenu() {
        partyMenu.SetActive(true);
        partyMenu.GetComponent<PartyMenuController>().ActivateMembers();
        escMenu.SetActive(false);
    }

    #endregion
}
