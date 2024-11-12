using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEntry : ForestBaseState
{
    public override void EnterState(ForestStateManager forest)
    {
        // Set the path blocks active
        forest.waterBlock.gameObject.SetActive(true);
        forest.earthBlock.gameObject.SetActive(true);

        // Set the bosses active
        forest.waterSlime.SetActive(true);
        forest.earthSlime.SetActive(true);
        forest.demonSlime.SetActive(true);
    }

    public override void UpdateState(ForestStateManager forest)
    {
        if (forest.waterDefeated && forest.earthDefeated && forest.demonDefeated)
        {
            forest.SwitchState(forest.clearState);
        }
        else if (forest.waterDefeated && forest.earthDefeated)
        {
            forest.SwitchState(forest.demonFightState);
        }
        else if (forest.waterDefeated)
        {
            forest.SwitchState(forest.waterClearState);
        } 
        else if (forest.earthDefeated)
        {
            forest.SwitchState(forest.earthClearState);
        }
    }
}
