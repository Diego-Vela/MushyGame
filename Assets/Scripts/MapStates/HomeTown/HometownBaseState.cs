using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HometownBaseState
{
    public abstract void EnterState(HometownStateManager hometown);

    public abstract void UpdateState(HometownStateManager hometown);
}
