using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using static UnityEngine.Rendering.DebugUI;

public class CharacterScript : MonoBehaviour
{

    public float movementSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;

    [SerializeField] private Camera cam;

    public bool pizzaArea, trashArea, ovenArea, plateArea;

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 90, 10f * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 10f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed /= 2;
        }
    }

    void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PizzaArea"))
        {
            pizzaArea = true;
        }
        if (other.CompareTag("TrashArea"))
        {
            trashArea = true;
        }
        if (other.CompareTag("OvenArea"))
        {
            ovenArea = true;
        }
        if (other.CompareTag("PlateArea"))
        {
            plateArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PizzaArea"))
        {
            pizzaArea = false;
        }
        if (other.CompareTag("TrashArea"))
        {
            trashArea = false;
        }
        if (other.CompareTag("OvenArea"))
        {
            ovenArea = false;
        }
        if (other.CompareTag("PlateArea"))
        {
            plateArea = false;
        }
    }
}