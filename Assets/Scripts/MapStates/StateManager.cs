using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public abstract class StateManager : MonoBehaviour
{
    // Access the GameState Object
    protected GameState gamestate;

    void Awake() 
    {
        gamestate = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    public abstract void Despawn(string name);
}
