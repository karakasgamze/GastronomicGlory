using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterIsWaitingState : WaiterBaseState
{
    private float waitTime;

    public override void EnterState(WaiterStateManager waiter)
    {
        waitTime = 30f;
        waiter.pizzaDelivered = false;
    }

    public override void UpdateState(WaiterStateManager waiter)
    {
        waitTime -= Time.deltaTime;
        if (waitTime > 0f)
        {
            if (waiter.pizzaDelivered)
            {
                waiter.SwitchState(waiter.TakesState);
            }
        }
        else
        {
            waiter.SwitchState(waiter.EmptyState);
        }
    }

    public override void ExitState(WaiterStateManager waiter)
    {

    }
}