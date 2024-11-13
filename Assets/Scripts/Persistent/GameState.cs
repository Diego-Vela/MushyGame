using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    // HomeTown
    public bool charlotte;
    public bool gunther;
    
    // Forest
    public bool waterDefeated;
    public bool earthDefeated;
    public bool demonDefeated;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

        waterDefeated = false;
        earthDefeated = false;
        demonDefeated = false;
    }

    public void ResetGame()
    {
        InitializeVariables();
    }

}
