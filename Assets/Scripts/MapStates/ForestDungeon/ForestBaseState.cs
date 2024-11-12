using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForestBaseState
{
    public abstract void EnterState(ForestStateManager forest);

    public abstract void UpdateState(ForestStateManager forest);
}
