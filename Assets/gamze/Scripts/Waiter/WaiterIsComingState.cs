using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterIsComingState : WaiterBaseState
{
    public override void EnterState(WaiterStateManager waiter)
    {
        waiter.MoveWaiterToTarget();
        waiter.Order();
    }

    public override void UpdateState(WaiterStateManager waiter)
    {
        if (waiter.atPlate)
        {
            waiter.SpawnImage();
            waiter.SwitchState(waiter.WaitingState);
        }
    }

    public override void ExitState(WaiterStateManager waiter)
    {
    }
}
