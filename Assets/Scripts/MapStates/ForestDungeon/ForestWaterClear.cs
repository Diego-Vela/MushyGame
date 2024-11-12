using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestWaterClear : ForestBaseState
{
    public override void EnterState(ForestStateManager forest)
    {
        // Set the path blocks active
        forest.waterBlock.gameObject.SetActive(false);
        forest.earthBlock.gameObject.SetActive(true);

        // Set the bosses active
        forest.waterSlime.SetActive(false);
        forest.earthSlime.SetActive(true);
        forest.demonSlime.SetActive(true);
    }

    public override void UpdateState(ForestStateManager forest)
    {
        if (forest.earthDefeated)
        {
            forest.SwitchState(forest.demonFightState);
        }
    }
}
