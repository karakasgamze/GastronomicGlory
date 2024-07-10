using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterTakesOrderState : WaiterBaseState
{
    public override void EnterState(WaiterStateManager waiter)
    {
        waiter.MoveBackWaiterToTable();
    }

    public override void UpdateState(WaiterStateManager waiter)
    {
        if (waiter.atTable)
        {
            waiter.SwitchState(waiter.ComingState);
        }
    }

    public override void ExitState(WaiterStateManager waiter)
    {

    }
}