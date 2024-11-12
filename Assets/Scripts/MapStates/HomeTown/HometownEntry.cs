using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HometownEntry : HometownBaseState
{
    public override void EnterState(HometownStateManager hometown)
    {
        hometown.charlotteNPC.gameObject.SetActive(true);
        hometown.guntherNPC.gameObject.SetActive(true);
    }

    public override void UpdateState(HometownStateManager hometown)
    {
        if (!hometown.charlotte && !hometown.gunther)
        {
            hometown.SwitchState(hometown.emptyState);
        }
        else if (!hometown.charlotte)
        {
            hometown.SwitchState(hometown.noCharlotteState);
        }
        else if (!hometown.gunther)
        {
            hometown.SwitchState(hometown.noGuntherState);
        } 
    }
}
