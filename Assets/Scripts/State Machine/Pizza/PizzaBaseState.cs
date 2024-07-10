using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PizzaBaseState
{
    public abstract void EnterState(PizzaStateManager pizza);

    public abstract void UpdateState(PizzaStateManager pizza);

    public abstract void ExitState(PizzaStateManager pizza);
}