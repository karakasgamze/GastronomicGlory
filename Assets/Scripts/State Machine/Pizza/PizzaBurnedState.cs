using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBurnedState : PizzaBaseState
{
    public override void EnterState(PizzaStateManager pizza)
    {
        pizza.ringbell.Stop();
        pizza.cooking.Stop();
        pizza.GetComponent<Renderer>().material = pizza.burned;
        //Debug.Log("Burned");
        pizza.unbaked = false;
        pizza.baked = false;
        pizza.burn = true;
    }

    public override void UpdateState(PizzaStateManager pizza)
    {

    }

    public override void ExitState(PizzaStateManager pizza)
    {

    }
}
