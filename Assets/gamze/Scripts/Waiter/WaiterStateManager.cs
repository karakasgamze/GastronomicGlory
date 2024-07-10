using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaiterStateManager : MonoBehaviour
{
    public WaiterBaseState currentState;
    public WaiterIsComingState ComingState = new WaiterIsComingState();
    public WaiterIsWaitingState WaitingState = new WaiterIsWaitingState();
    public WaiterTakesOrderState TakesState = new WaiterTakesOrderState();
    public WaiterGoesEmptyState EmptyState = new WaiterGoesEmptyState();

    public GameObject orderImage;
    public GameObject waiter;
    public Transform targetPoint;
    public Transform tablePoint;
    public Transform spawnImage;
    public Object imagePrefab;

    public string currentPizzaName;
    public OrderManager orderManagerScript;

    public bool imageSpawned;

    public List<PizzaRecipe> availablePizzas;

    private Animator waiterAnimator;

    public float CharacterSpeed;
    public bool pizzaDelivered = false;

    public bool atTable, atPlate;

    void Start()
    {
        currentState = ComingState;
        currentState.EnterState(this);
        waiterAnimator = GetComponent<Animator>();

        FindObjectOfType<PizzaStateManager>().servedState.waiterStateManager = this;


    }


    void Update()
    {
        PlayAnimation();
        currentState.UpdateState(this);
    }



    public void MoveWaiterToTarget()
    {
        StartCoroutine(MoveWaiterCoroutine());
    }

    private IEnumerator MoveWaiterCoroutine()
    {
        atTable = false;
        CharacterSpeed = 5f;
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        while (Vector3.Distance(waiter.transform.position, targetPoint.position) > 0.5f)
        {
            waiter.transform.position = Vector3.MoveTowards(waiter.transform.position, targetPoint.position, CharacterSpeed * Time.deltaTime);
            yield return null;
        }
        CharacterSpeed = 0f;
        atPlate = true;
    }


    public void MoveBackWaiterToTable()
    {
        StartCoroutine(MoveBackWaiterCoroutine());
    }
    private IEnumerator MoveBackWaiterCoroutine()
    {
        atPlate = false;
        CharacterSpeed = 5f;
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        while (Vector3.Distance(waiter.transform.position, tablePoint.position) > 0.5f)
        {
            waiter.transform.position = Vector3.MoveTowards(waiter.transform.position, tablePoint.position, CharacterSpeed * Time.deltaTime);
            yield return null;
        }
        CharacterSpeed = 0f;
        atTable = true;
    }

    public void PizzaDelivered()
    {
        if (currentState == WaitingState)
        {
            pizzaDelivered = true;
            //SwitchState(TakesState);
            Debug.Log("Pizzayý götürüyorum");
        }
        else
        {
            Debug.Log("Yetismedi");
            //SwitchState(EmptyState);
        }
    }
    public void SwitchState(WaiterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        Debug.Log(currentState);
    }
    public void SpawnImage()
    {
        if (!imageSpawned)
        {
            Instantiate(imagePrefab, spawnImage.position, spawnImage.rotation);
            imageSpawned = true;
        }
    }
    public PizzaRecipe GetRandomOrder()
    {
        if (availablePizzas.Count == 0)
        {
            Debug.LogError("No pizza recipes available!");
            return null;
        }

        int randomIndex = Random.Range(0, availablePizzas.Count);
        return availablePizzas[randomIndex];
    }
    public void InteractWithPizzaImage()
    {
        if (orderImage != null && orderImage.name == currentPizzaName)
        {
            orderImage.SetActive(true);
        }
    }
    public void PlayAnimation()
    {
        waiterAnimator.SetFloat("Speed", CharacterSpeed);
    }

    public void Order()
    {
        PizzaRecipe randomOrder = GetRandomOrder();
        if (randomOrder != null)
        {
            currentPizzaName = randomOrder.pizzaName;
            Debug.Log("Garson: Ýþte size bir " + currentPizzaName + " sipariþi!");
        }

        if (orderManagerScript != null)
        {
            orderManagerScript.SetCurrentPizzaName(currentPizzaName);
        }
    }
}