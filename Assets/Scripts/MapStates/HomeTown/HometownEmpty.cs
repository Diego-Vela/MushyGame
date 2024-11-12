using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HometownEmpty : HometownBaseState
{
    public override void EnterState(HometownStateManager hometown)
    {
        hometown.charlotteNPC.gameObject.SetActive(false);
        hometown.guntherNPC.gameObject.SetActive(false);
    }

    public override void UpdateState(HometownStateManager hometown)
    {
        // Never Called
    }
}