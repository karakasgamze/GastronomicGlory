using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCookedState : PizzaBaseState
{
    public override void EnterState(PizzaStateManager pizza)
    {
        //Debug.Log("Ready to serve");
        pizza.unbaked = false;
        pizza.baked = true;
        pizza.burn = false;
        pizza.ringbell.Stop();
        pizza.cooking.Stop();
    }

    public override void UpdateState(PizzaStateManager pizza)
    {
        if (pizza.grabbing.inOven)
        {
            //Debug.Log("Why did you put it in oven again?");
            pizza.SwitchState(pizza.cookingState);
        }

        if (pizza.grabbing.inPlate)
        {
            pizza.SwitchState(pizza.servedState);
        }
    }

    public override void ExitState(PizzaStateManager pizza)
    {

    }
}
