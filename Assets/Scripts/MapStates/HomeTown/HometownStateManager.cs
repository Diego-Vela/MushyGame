using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class HometownStateManager : StateManager
{
    #region variables

    // State variables
    //HometownBaseState currentState;
    //public HometownEntry entryState = new HometownEntry();
    //public HometownNoCharlotte noCharlotteState = new HometownNoCharlotte();
    //public HometownNoGunther noGuntherState = new HometownNoGunther();
    //public HometownEmpty emptyState = new HometownEmpty();

    // References to objects
    public GameObject charlotteNPC;
    public GameObject guntherNPC;
    public GameObject daisyNPC;

    // Bools to characters are active
    public bool charlotte;
    public bool gunther;
    public bool daisy;
    
    #endregion
    #region state-managers
    // Start is called before the first frame update
    void Start()
    {
        GetCurrentState();
        SetCurrentState();
    }

    void GetCurrentState()
    {
        if(gamestate == null) {
            Debug.Log("Gamestate is null");
        } else {
            charlotte = gamestate.charlotte;
            gunther = gamestate.gunther;
            daisy = gamestate.daisy;
        }
    }

    void SetCurrentState()
    {
        charlotteNPC.SetActive(charlotte);
        guntherNPC.SetActive(gunther);
        daisyNPC.SetActive(daisy);
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
            case "Daisy":
                daisy = false;
                gamestate.daisy = false;
                break;
            default:
                break;
        }
    }
    #endregion
}
