using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestClear : ForestBaseState
{
    public override void EnterState(ForestStateManager forest)
    {
        // Set the path blocks active
        forest.waterBlock.gameObject.SetActive(false);
        forest.earthBlock.gameObject.SetActive(false);

        // Set the bosses active
        forest.waterSlime.SetActive(false);
        forest.earthSlime.SetActive(false);
        forest.demonSlime.SetActive(false);
    }

    public override void UpdateState(ForestStateManager forest)
    {
        // Never called
    }
}
