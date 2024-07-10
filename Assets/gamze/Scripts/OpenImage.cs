using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenImage : MonoBehaviour
{
    public OrderManager orderManagerScript;
    bool isImageOpen = false;

    public AudioSource paperSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Order"))
                {
                    paperSound.Play();
                    ToggleImage();
                }
            }
        }
    }

    private void ToggleImage()
    {

        if (isImageOpen)
        {
            Debug.Log("Order image is being closed.");
            orderManagerScript.CloseCurrentPizzaImage();
            isImageOpen = false;
        }
        else
        {
            Debug.Log("Order image is being opened.");
            orderManagerScript.OpenCurrentPizzaImage();
            isImageOpen = true;
        }
    }
}
