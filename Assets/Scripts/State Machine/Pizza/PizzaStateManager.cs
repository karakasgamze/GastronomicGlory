using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaStateManager : MonoBehaviour
{
    PizzaBaseState currentState;
    public PizzaReadyToCookState readyToCookState = new PizzaReadyToCookState();
    public PizzaCookedState CookedState = new PizzaCookedState();
    public PizzaCookingState cookingState = new PizzaCookingState();
    public PizzaBurnedState burnedState = new PizzaBurnedState();
    public PizzaServedState servedState = new PizzaServedState();
    public GrabStateManager grabbing;
    public MeshRenderer pizzaMesh;

    public Material uncooked, cooked, burned;

    public GameObject tomato, cheese, olives, mushroom;
    public bool margarita, mushrooms, veggie, mixed;
    public bool unbaked, baked, burn;
    public PickableItem pickable;
    public AudioSource cooking, ringbell;
    public Transform targetPoint;
    public GameObject pisa;
    public int pizzaServed;

    public Vector3 dough = new Vector3(3.8f, 1.84f, -12.9f);

    void Start()
    {
        pizzaMesh = GetComponent<MeshRenderer>();
        pickable = GetComponent<PickableItem>();
        mushroom.gameObject.SetActive(false);
        tomato.gameObject.SetActive(false);
        olives.gameObject.SetActive(false);
        cheese.gameObject.SetActive(false);
        currentState = readyToCookState;
        currentState.EnterState(this);

    }

    void Update()
    {
        currentState.UpdateState(this);
        PizzaCheck();
    }

    public void SwitchState(PizzaBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void PizzaCheck()
    {
        if (!grabbing.hasMushroom && !grabbing.hasOlive)
        {
            margarita = true;
            mushrooms = false;
            veggie = false;
            mixed = false;
        }

        if (grabbing.hasMushroom && !grabbing.hasOlive)
        {
            margarita = false;
            mushrooms = true;
            veggie = false;
            mixed = false;
        }

        if (!grabbing.hasMushroom && grabbing.hasOlive)
        {
            margarita = false;
            mushrooms = false;
            veggie = true;
            mixed = false;
        }

        if (grabbing.hasMushroom && grabbing.hasOlive)
        {
            margarita = false;
            mushrooms = false;
            veggie = false;
            mixed = true;
        }
    }

    private void OnDisable()
    {
        mushroom.gameObject.SetActive(false);
        tomato.gameObject.SetActive(false);
        olives.gameObject.SetActive(false);
        cheese.gameObject.SetActive(false);
        pizzaMesh.material = uncooked;
        margarita = false; mushrooms = false; veggie = false; mixed = false;
        unbaked = true; baked = false; burn = false;
        grabbing.inOven = false; grabbing.inPlate = false;
        grabbing.hasTomato = false; grabbing.hasCheese = false; grabbing.hasMushroom = false; grabbing.hasOlive = false;
    }
}