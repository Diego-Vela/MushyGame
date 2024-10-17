using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public GameObject continueButton; // Reference to the Continue button

    void Start()
    {
        Time.timeScale = 1f;
        // Check if a save file exists; if not, disable the Continue button
        if (!SaveSystem.HasSavedData())
        {
            continueButton.GetComponent<Button>().interactable = false; // Disable button if no saved data
        }
    }
    
    public void Play()
    {
        SaveSystem.DeleteSaveData();
        SceneManager.LoadScene("HomeTown");
    }

    public void Continue()
    {
        if (SaveSystem.HasSavedData())
        {
            PlayerData data = SaveSystem.loadPlayer(); // Load the saved player data
            if (data != null)
            {
                // Store the data temporarily for use in the next scene
                DataPersistenceManager.Instance.SetPlayerData(data);

                // Load the game scene (the scene with the player in it)
                SceneManager.LoadScene("HomeTown"); // Replace "GameScene" with your actual scene name
            }
        }
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        //Code for using unity editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}