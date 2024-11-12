using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HometownNoCharlotte : HometownBaseState
{
    public override void EnterState(HometownStateManager hometown)
    {
        hometown.charlotteNPC.gameObject.SetActive(false);
        hometown.guntherNPC.gameObject.SetActive(true);
    }

    public override void UpdateState(HometownStateManager hometown)
    {
        if (!hometown.gunther)
        {
            hometown.SwitchState(hometown.emptyState);
        }
    }
}