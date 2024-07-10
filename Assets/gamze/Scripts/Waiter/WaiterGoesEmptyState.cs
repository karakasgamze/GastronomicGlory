using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterGoesEmptyState : WaiterBaseState
{
    public override void EnterState(WaiterStateManager waiter)
    {
        waiter.Order();
        waiter.SwitchState(waiter.WaitingState);
    }

    public override void UpdateState(WaiterStateManager waiter)
    {
    }

    public override void ExitState(WaiterStateManager waiter)
    {

    }
}