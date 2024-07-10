using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaServedState : PizzaBaseState
{
    public Timer timerScript;
    public WaiterStateManager waiterStateManager;

    public override void EnterState(PizzaStateManager pizza)
    {
        Debug.Log("It's served");
        pizza.pizzaServed++;

        if (waiterStateManager != null)
        {
            waiterStateManager.PizzaDelivered();
        }
        else
        {
            Debug.LogWarning("WaiterStateManager is not set");
        }

        if (timerScript != null)
        {
            timerScript.PizzaServed();
        }
        else
        {
            Debug.LogWarning("Timer script is not working");
        }

    }

    public override void UpdateState(PizzaStateManager pizza)
    {

    }


    public override void ExitState(PizzaStateManager pizza)
    {

    }
}
