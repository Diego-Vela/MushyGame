using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuController : MonoBehaviour {
    public void GoToTitle()
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
}