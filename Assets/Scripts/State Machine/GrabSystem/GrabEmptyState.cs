using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GrabEmptyState : GrabBaseState
{
    public override void EnterState(GrabStateManager grab)
    {
        grab.pickUpSound.enabled = false;
    }

    public override void UpdateState(GrabStateManager grab)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Ray ray = grab.characterCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f))
            {
                Debug.DrawRay(ray.origin, hit.point, Color.yellow);
                var pickable = hit.transform.GetComponent<PickableItem>();

                if (pickable)
                {
                    grab.pickedItem = pickable;
                    grab.pickUpSound.enabled = true;
                    grab.trashSound.enabled = false;
                    if (grab.pickedItem.CompareTag("Pizza"))
                    {
                        if (grab.hasTomato && grab.hasCheese)
                        {
                            grab.SwitchState(grab.pizzaState);
                        }
                    }
                    else
                    {
                        grab.SpawnObject(pickable.gameObject);

                        if (pickable.CompareTag("Tomato"))
                        {
                            grab.SwitchState(grab.tomatoState);
                        }

                        if (pickable.CompareTag("Cheese"))
                        {
                            grab.SwitchState(grab.cheeseState);
                        }

                        if (pickable.CompareTag("Olive"))
                        {
                            grab.SwitchState(grab.oliveState);
                        }

                        if (pickable.CompareTag("Mushroom"))
                        {
                            grab.SwitchState(grab.mushroomState);
                        }
                    }
                }
            }
        }
    }

    public override void ExitState(GrabStateManager grab)
    {

    }
}