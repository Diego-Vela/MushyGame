using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestStateManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        currentState = entryState;

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
}
