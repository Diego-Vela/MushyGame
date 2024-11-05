using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestWaterClear : ForestBaseState
{
    public void EnterState(ForestStateManager forest);

    public void UpdateState(ForestStateManager forest);

    public void OnCollisionEnter(ForestStateManager forest);
}
