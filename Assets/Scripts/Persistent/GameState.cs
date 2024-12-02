using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    // HomeTown
    public bool charlotte;
    public bool gunther;
    public bool daisy;
    
    // Forest
    public bool waterDefeated;
    public bool earthDefeated;
    public bool demonDefeated;

    
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

        InitializeVariables();
    }

    private void InitializeVariables()
    {
        charlotte = true;
        gunther = true;
        daisy = true;

        waterDefeated = false;
        earthDefeated = false;
        demonDefeated = false;
    }

    public void ResetGame()
    {
        InitializeVariables();
    }

}
