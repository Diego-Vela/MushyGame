using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestClear : ForestBaseState
{
    public void EnterState(ForestStateManager forest);

    public void UpdateState(ForestStateManager forest);

    public void OnCollisionEnter(ForestStateManager forest);
}
