using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEarthClear : ForestBaseState
{
    public override void EnterState(ForestStateManager forest)
    {
        // Set the path blocks active
        forest.waterBlock.gameObject.SetActive(true);
        forest.earthBlock.gameObject.SetActive(false);

        // Set the bosses active
        forest.waterSlime.SetActive(true);
        forest.earthSlime.SetActive(false);
        forest.demonSlime.SetActive(true);
    }

    public override void UpdateState(ForestStateManager forest)
    {
    }
}
