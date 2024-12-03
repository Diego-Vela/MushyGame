using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    private Party party;
    private GameState gamestate;

    // Set up references
    void Start()
    {
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        gamestate = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

        ResetObjects();
        Debug.Log("GameState Reset");
    }

    private void ResetObjects()
    {
        party.DeleteParty();
        gamestate.ResetGame();
    }

}
