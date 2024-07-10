using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaReadyToCookState : PizzaBaseState
{


    public override void EnterState(PizzaStateManager pizza)
    {

        //Debug.Log("Ready to cook");
        pizza.unbaked = true;
        pizza.baked = false;
        pizza.burn = false;

    }

    public override void UpdateState(PizzaStateManager pizza)
    {
        if (pizza.grabbing.inOven)
        {
            pizza.SwitchState(pizza.cookingState);
        }
    }

    public override void ExitState(PizzaStateManager pizza)
    {

    }
}
