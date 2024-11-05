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
        if 
    }

    public void OnCollisionEnter(ForestStateManager forest);
}
