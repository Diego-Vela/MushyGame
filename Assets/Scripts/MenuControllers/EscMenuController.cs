using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenuController : MonoBehaviour
{
    #region variables
    public GameObject escMenu; // The escape menu UI panel
    public GameObject partyMenu; // Party Menu Controller
    public GameObject buttons; // buttonsContainer for escMenu
    public GameObject settings; // Settings panel
    public GameObject settingsContainer;
    public GameObject controls;
    public GameObject brightness;
    private GameObject brightnessCover;
    public GameObject brightnessMenu;
    public Slider brightnessSlider;
    private Player player; // Reference to player for saving
    public GameObject volumeMenu; // Reference to the volumeSlider
    public Slider volumeSlider; // Reference to the slider
    private AmbientMusicManager music; // Reference to the audioSource component

    public GameObject escButton;

    private bool isMenuActive;
    #endregion

    #region Global Functions
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        brightnessCover = GameObject.FindGameObjectWithTag("BrightnessCover");
        music = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AmbientMusicManager>();
        escMenu.SetActive(false);
        partyMenu.SetActive(false);
        settings.SetActive(false);
        escButton.SetActive(true);
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    private void ResetMenu()
    {
        escMenu.SetActive(true);
        buttons.SetActive(true);
        settings.SetActive(false);
        partyMenu.SetActive(false);
        volumeMenu.SetActive(false);
        settingsContainer.SetActive(false);
    }

    // Resumes the game and hides the escape menu
    public void ResumeGame()
    {
        ResetMenu();
        escMenu.SetActive(false);
        Time.timeScale = 1;
        isMenuActive = false;
        escButton.SetActive(true);
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
        escButton.SetActive(false);
    }
    
    public void Back() {
        ResetMenu();
    }
    #endregion
    #region Default Menu
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

    public void Save() {
        player.Save();
    }
    #endregion

    #region Show Menu Functions
    public void PartyMenu() {
        partyMenu.SetActive(true);
        partyMenu.GetComponent<PartyMenuController>().ActivateMembers();
        escMenu.SetActive(false);
    }

    public void SettingsMenu() {
        settings.SetActive(true);
        settingsContainer.SetActive(false);

    }
    #endregion

    #region Settings Functions

    public void ShowControls() {
        settingsContainer.SetActive(true);
        controls.SetActive(true);
        volumeMenu.SetActive(false);
        brightnessMenu.SetActive(false);
    }

    public void ShowAudioSettings() {
        settingsContainer.SetActive(true);
        controls.SetActive(false);
        volumeMenu.SetActive(true);
        brightnessMenu.SetActive(false);
        volumeSlider.value = music.GetVolume();
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void ShowBrightnessSettings() {
        settingsContainer.SetActive(true);
        Color currentColor = brightnessCover.GetComponent<Image>().color;
        
        controls.SetActive(false);
        volumeMenu.SetActive(false);
        brightnessMenu.SetActive(true);
        brightnessSlider.value = 1-currentColor.a;
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }


    public void SetBrightness(float brightness) {
        Image brightnessCoverImage = brightnessCover.GetComponent<Image>();
        Color currentColor = brightnessCoverImage.color;

        currentColor.a = 1f - brightness;

        brightnessCoverImage.color = currentColor;
    }
    public void SetVolume(float volume) {
        music.ChangeVolume(volume);
    }
    #endregion
}
