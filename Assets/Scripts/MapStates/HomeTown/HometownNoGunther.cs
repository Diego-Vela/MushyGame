using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HometownNoGunther : HometownBaseState
{
    public override void EnterState(HometownStateManager hometown)
    {
        hometown.charlotteNPC.gameObject.SetActive(true);
        hometown.guntherNPC.gameObject.SetActive(false);
    }

    public override void UpdateState(HometownStateManager hometown)
    {
        if (!hometown.charlotte)
        {
            hometown.SwitchState(hometown.emptyState);
        }
    }
}