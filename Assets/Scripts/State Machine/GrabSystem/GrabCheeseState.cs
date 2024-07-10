using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GrabCheeseState : GrabBaseState
{
    public override void EnterState(GrabStateManager grab)
    {

        grab.inPlate = false;
        grab.inOven = false;

        grab.pickedItem.Rb.velocity = new Vector3(0f, 0f, 0f);
        grab.pickedItem.Rb.angularVelocity = new Vector3(0f, 0f, 0f);
        grab.pickedItem.Rb.isKinematic = true;
        grab.pickedItem.transform.SetParent(null);
        grab.pickedItem.transform.SetParent(grab.slot);
        grab.pickedItem.transform.position = grab.slot.transform.position;
        grab.pickedItem.transform.eulerAngles = Vector3.zero;
        grab.pickedItem.transform.rotation = Quaternion.identity;
        grab.pickedItem.transform.localRotation = Quaternion.identity;
        grab.pickedItem.boxHit.enabled = false;
    }
    public override void UpdateState(GrabStateManager grab)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!grab.character.pizzaArea && !grab.character.trashArea)
            {
                Debug.Log("Sosu yere dökemezsin");
            }

            else
            {
                if (grab.character.pizzaArea)
                {
                    if (grab.hasTomato)
                    {
                        grab.pizza.cheese.gameObject.SetActive(true);
                        grab.hasCheese = true;
                        grab.pickedItem.transform.SetParent(null);
                        grab.pickedItem.gameObject.SetActive(false);
                        grab.pickedItem = null;
                        grab.SwitchState(grab.emptyState);

                    }
                    else
                    {
                        Debug.Log("Önce domates sosu");
                    }
                }

                if (grab.character.trashArea)
                {
                    grab.pickedItem.transform.SetParent(null);
                    grab.pickedItem.gameObject.SetActive(false);
                    grab.pickedItem = null;
                    grab.trashSound.enabled = true;
                    grab.SwitchState(grab.emptyState);
                }

            }
        }
    }

    public override void ExitState(GrabStateManager grab)
    {

    }
}
