using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ForestStateManager : StateManager
{
    #region variables
    // Access the GameState Object

    // State variables
    ForestBaseState currentState;
    public ForestEntry entryState = new ForestEntry();
    public ForestWaterClear waterClearState = new ForestWaterClear();
    public ForestEarthClear earthClearState = new ForestEarthClear();
    public ForestDemonFight demonFightState = new ForestDemonFight();
    public ForestClear clearState = new ForestClear();

    // References to objects
    public Tilemap waterBlock;
    public Tilemap earthBlock;
    public GameObject waterSlime;
    public GameObject earthSlime;
    public GameObject demonSlime;

    // Bools to store if bosses are defeated
    public bool waterDefeated;
    public bool earthDefeated;
    public bool demonDefeated;
    
    #endregion
    #region state-managers
    // Start is called before the first frame update
    void Start()
    {
        currentState = entryState;
        GetCurrentState();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(ForestBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    void GetCurrentState()
    {
        if(gamestate == null) {
            Debug.Log("Gamestate is null");
        } else {
            waterDefeated = gamestate.waterDefeated;
            earthDefeated = gamestate.earthDefeated;
            demonDefeated = gamestate.demonDefeated;
        }

    }

    #endregion
    #region defeat-bosses
    public override void Despawn(string name)
    {
        switch(name)
        {
            case "WaterSlime":
                waterDefeated = true;
                gamestate.waterDefeated = true;
                break;
            case "EarthSlime":
                earthDefeated = true;
                gamestate.earthDefeated = true;
                break;
            case "DemonSlime":
                demonDefeated = true;
                gamestate.demonDefeated = true;
                break;
            default:
                break;
        }
    }
    #endregion


}
