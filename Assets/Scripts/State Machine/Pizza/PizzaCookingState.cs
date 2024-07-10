using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCookingState : PizzaBaseState
{
    float cookingTime;
    float burningTime;

    public override void EnterState(PizzaStateManager pizza)
    {
        cookingTime = 5f;
        burningTime = 10f;
        pizza.cooking.Play();
        pizza.StartCoroutine(MovePizza(pizza));
    }

    public override void UpdateState(PizzaStateManager pizza)
    {
        if (!pizza.baked)
        {
            cookingTime -= Time.deltaTime;
            if (cookingTime <= 0)
            {
                pizza.pizzaMesh.material = pizza.cooked;
                pizza.unbaked = false; pizza.baked = true;
                pizza.ringbell.Play();
            }

            if (!pizza.grabbing.inOven)
            {
                pizza.cooking.Stop();
                pizza.SwitchState(pizza.readyToCookState);
            }
        }


        if (pizza.baked)
        {
            burningTime -= Time.deltaTime;

            if (burningTime <= 0)
            {
                pizza.pizzaMesh.material = pizza.burned;
                pizza.baked = false; pizza.burn = true;
                pizza.SwitchState(pizza.burnedState);
            }
            else if (!pizza.grabbing.inOven)
            {

                pizza.SwitchState(pizza.CookedState);
            }
        }
    }

    public override void ExitState(PizzaStateManager pizza)
    {
        pizza.StartCoroutine(MovePizzaBack(pizza));
    }

    IEnumerator MovePizza(PizzaStateManager pizza)
    {
        float speed = 2f;
        while (Vector3.Distance(pizza.pisa.transform.position, pizza.targetPoint.position) > 0.1f)
        {
            pizza.pisa.transform.position = Vector3.MoveTowards(pizza.pisa.transform.position, pizza.targetPoint.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MovePizzaBack(PizzaStateManager pizza)
    {
        float speed = 2f;
        while (Vector3.Distance(pizza.pisa.transform.position, Vector3.zero) > 0.1f)
        {
            pizza.pisa.transform.position = Vector3.MoveTowards(pizza.pisa.transform.position, Vector3.zero, speed * Time.deltaTime);
            yield return null;
        }
    }
}
