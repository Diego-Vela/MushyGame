using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDemonFight : ForestBaseState
{
    public override void EnterState(ForestStateManager forest)
    {
        // Set the path blocks active
        forest.waterBlock.gameObject.SetActive(false);
        forest.earthBlock.gameObject.SetActive(false);

        // Set the bosses active
        forest.waterSlime.SetActive(false);
        forest.earthSlime.SetActive(false);
        forest.demonSlime.SetActive(true);
    }

    public override void UpdateState(ForestStateManager forest)
    {
        if (forest.demonDefeated)
        {
            forest.SwitchState(forest.clearState);
        }
    }

}
