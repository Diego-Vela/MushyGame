using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public GameObject continueButton; // Reference to the Continue button
    public GameObject deleteSaveButton; // Reference to the Delete Save Data button
    public GameObject mainPanel;
    public GameObject controlPanel;
    private PartyCreator partyCreator;

    void Start()
    {
        Time.timeScale = 1f;
        ResetPanels();
        partyCreator = GameObject.FindGameObjectWithTag("PartyCreator").GetComponent<PartyCreator>();
    }

    void Update()
    {
        // Check if a save file exists; if not, disable the Continue button
        if (!SaveSystem.HasSavedData())
        {
            continueButton.GetComponent<Button>().interactable = false; // Disable button if no saved data
            deleteSaveButton.GetComponent<Button>().interactable = false;
        }
    }
    
    public void Play()
    {
        partyCreator.AddCharacterByName("Protagonist");
        SceneManager.LoadScene("HomeTown");
    }

    public void ReturnToMain()
    {
        ResetPanels();
    }

    public void Controls()
    {
        ShowControls();
    }

    public void Continue()
    {
        if (SaveSystem.HasSavedData())
        {
            SaveData data = SaveSystem.Load(); // Load the saved player data
            if (data != null)
            {
                // Store the data temporarily for use in the next scene
                SaveManager.Instance.SetUpData(data);
            }
        }
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSaveData();
    }

    public void QuitGame()
    {
        Application.Quit();
        //Code for using unity editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void ResetPanels()
    {
        mainPanel.SetActive(true);
        controlPanel.SetActive(false);
    }

    private void ShowControls()
    {
        mainPanel.SetActive(false);
        controlPanel.SetActive(true);   
    }
}