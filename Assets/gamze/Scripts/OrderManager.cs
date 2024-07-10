using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public WaiterStateManager waiterStateManagerScript;

    public GameObject veggieImage;
    public GameObject mixedImage;
    public GameObject mushroomImage;
    public GameObject margheritaImage;

    private string currentPizzaName;

    public void SetCurrentPizzaName(string pizzaName)
    {
        currentPizzaName = pizzaName;
    }


    public void OpenCurrentPizzaImage()
    {     
        switch (currentPizzaName)
        {
            case "Veggie":
                veggieImage.SetActive(true);
                break;
            case "Mixed":
                mixedImage.SetActive(true);
                break;
            case "Mushroom":
                mushroomImage.SetActive(true);
                break;
            case "Margherita":
                margheritaImage.SetActive(true);
                break;
        }
    }

    public void CloseCurrentPizzaImage()
    {
        switch (currentPizzaName)
        {
            case "Veggie":
                veggieImage.SetActive(false);
                break;
            case "Mixed":
                mixedImage.SetActive(false);
                break;
            case "Mushroom":
                mushroomImage.SetActive(false);
                break;
            case "Margherita":
                margheritaImage.SetActive(false);
                break;
        }
    }


}
