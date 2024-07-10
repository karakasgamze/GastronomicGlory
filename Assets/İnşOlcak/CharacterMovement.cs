using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Camera cam;
    public AudioSource footstep;


    public bool pizzaArea, trashArea, ovenArea, plateArea;
    public Vector3 move;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (x != 0 || z != 0)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 90, 10f * Time.deltaTime);
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 10f * Time.deltaTime);
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.5f;
        }

        FootstepSound();

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

    void FootstepSound()
    {
        if (move.magnitude != 0)
        {
            footstep.enabled = true;
        }
        else
        {
            footstep.enabled = false;
        }
    }
}