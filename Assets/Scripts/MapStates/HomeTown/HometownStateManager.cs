using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class HometownStateManager : StateManager
{
    #region variables

    // State variables
    HometownBaseState currentState;
    public HometownEntry entryState = new HometownEntry();
    public HometownNoCharlotte noCharlotteState = new HometownNoCharlotte();
    public HometownNoGunther noGuntherState = new HometownNoGunther();
    public HometownEmpty emptyState = new HometownEmpty();

    // References to objects
    public GameObject charlotteNPC;
    public GameObject guntherNPC;

    // Bools to characters are active
    public bool charlotte;
    public bool gunther;
    
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
        if (charlotteNPC != null && !charlotteNPC.activeSelf && charlotte)
        {
            Despawn("Charlotte");
        }
        if (guntherNPC != null && !guntherNPC.activeSelf && gunther)
        {
            Despawn("Gunther");
        }
        currentState.UpdateState(this);
    }

    public void SwitchState(HometownBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    void GetCurrentState()
    {
        if(gamestate == null) {
            Debug.Log("Gamestate is null");
        } else {
            charlotte = gamestate.charlotte;
            gunther = gamestate.gunther;
        }
    }

    #endregion
    #region modify-npcs
    public override void Despawn(string name)
    {
        switch(name)
        {
            case "Gunther":
                gunther = false;
                gamestate.gunther = false;
                break;
            case "Charlotte":
                charlotte = false;
                gamestate.charlotte = false;
                break;
            default:
                break;
        }
    }
    #endregion
}
