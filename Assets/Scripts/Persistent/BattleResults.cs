using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleResults : MonoBehaviour
{
    public static BattleResults instance;

    public string enemyName;
    
    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates if they exist
        }
    }


    public void BattleWon()
    {
        // Load any logic from important battles
        StateManager statemanager = GameObject.FindWithTag("StateManager").GetComponent<StateManager>();
        if (statemanager != null) {
            statemanager.Despawn(enemyName);
        }
    }

}

