using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabStateManager : MonoBehaviour
{
    GrabBaseState currentState;
    public GrabEmptyState emptyState = new GrabEmptyState();
    public GrabCheeseState cheeseState = new GrabCheeseState();
    public GrabOliveState oliveState = new GrabOliveState();
    public GrabPizzaState pizzaState = new GrabPizzaState();
    public GrabTomatoState tomatoState = new GrabTomatoState();
    public GrabMushroomState mushroomState = new GrabMushroomState();

    public Camera characterCamera;
    public Transform slot;
    public PickableItem pickedItem;
    public Transform ovenTransform, plateTransform, pizzaTransform;
    public CharacterMovement character;
    public PizzaStateManager pizza;
    public GameObject pisa;
    public GameObject ovenFire1, ovenFire2, light1, light2;
    public AudioSource pickUpSound, trashSound, servingSound;

    public bool inPlate, inOven;
    public bool hasCheese, hasOlive, hasTomato, hasMushroom;

    void Start()
    {
        currentState = emptyState;
        currentState.EnterState(this);
        ovenFire1.SetActive(false);
        ovenFire2.SetActive(false);
        light1.SetActive(false);
        light2.SetActive(false);
    }
    private void Update()
    {
        currentState.UpdateState(this);

        if (inPlate)
        {
            if (pizza.baked)
            {
                if (pizza.margarita)
                {
                    Debug.Log("Margarita");
                }

                if (pizza.mushrooms)
                {
                    Debug.Log("Mushrooms");
                }

                if (pizza.veggie)
                {
                    Debug.Log("Veggie");
                }

                if (pizza.mixed)
                {
                    Debug.Log("Mixed");
                }
            }

            if (pizza.unbaked)
            {
                Debug.Log("Pizzayý piþirmeyi unuttun");
            }

            if (pizza.burn)
            {
                Debug.Log("Bu pizza yanmýþ");
            }
        }

        if (inOven)
        {
            ovenFire1.SetActive(true);
            ovenFire2.SetActive(true);
            light1.SetActive(true);
            light2.SetActive(true);
        }
        else
        {
            ovenFire1.SetActive(false);
            ovenFire2.SetActive(false);
            light1.SetActive(false);
            light2.SetActive(false);
        }
    }

    public void SwitchState(GrabBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void SpawnObject(GameObject picked)
    {
        Instantiate(picked, picked.transform.position, picked.transform.rotation);
    }
}
