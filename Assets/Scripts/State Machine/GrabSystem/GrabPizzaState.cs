using System.Collections;
using UnityEngine;

public class GrabPizzaState : GrabBaseState
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

            if (!grab.character.trashArea && !grab.character.plateArea && !grab.character.ovenArea && !grab.character.pizzaArea)
            {
                Debug.Log("Pizzayý yere dökemezsin");
            }
            else
            {

                if (grab.character.trashArea)
                {
                    grab.pickedItem.transform.SetParent(null);
                    grab.pickedItem.transform.position = grab.pizzaTransform.transform.position;
                    grab.pickedItem.transform.rotation = Quaternion.identity;
                    grab.pickedItem.transform.localRotation = Quaternion.identity;
                    grab.pickedItem.boxHit.enabled = true;
                    grab.pickedItem = null;
                    grab.pizza.enabled = false;
                    grab.pizza.enabled = true;
                    grab.trashSound.enabled = true;
                    grab.pizza.SwitchState(grab.pizza.readyToCookState);
                    grab.SwitchState(grab.emptyState);
                }
                else
                {

                    if (!grab.pizza.burn)
                    {

                        if (grab.character.plateArea && grab.pizza.baked)
                        {
                            grab.pickedItem.transform.SetParent(null);
                            grab.pickedItem.transform.position = grab.plateTransform.transform.position;
                            grab.pickedItem.transform.rotation = Quaternion.identity;
                            grab.pickedItem.transform.localRotation = Quaternion.identity;
                            grab.pickedItem.boxHit.enabled = true;
                            grab.inPlate = true;
                            grab.servingSound.enabled = true;
                            grab.StartCoroutine(Served(grab));
                        }

                        if (grab.character.ovenArea)
                        {
                            grab.pickedItem.transform.SetParent(null);
                            grab.pickedItem.transform.position = grab.ovenTransform.transform.position;
                            grab.pickedItem.transform.rotation = Quaternion.identity;
                            grab.pickedItem.transform.localRotation = Quaternion.identity;
                            grab.pickedItem.boxHit.enabled = true;
                            grab.inOven = true;
                        }

                        if (grab.character.pizzaArea)
                        {
                            grab.pickedItem.transform.SetParent(null);
                            grab.pickedItem.transform.position = grab.pizzaTransform.transform.position;
                            grab.pickedItem.transform.rotation = Quaternion.identity;
                            grab.pickedItem.transform.localRotation = Quaternion.identity;
                            grab.pickedItem.boxHit.enabled = true;
                        }
                        grab.pickedItem = null;
                        grab.SwitchState(grab.emptyState);
                    }
                }
            }
        }
    }

    public override void ExitState(GrabStateManager grab)
    {

    }

    IEnumerator Served(GrabStateManager grab)
    {

        yield return new WaitForSeconds(2);
        grab.servingSound.enabled = false;
        grab.pizza.enabled = false;
        grab.pizza.enabled = true;
        grab.pisa.transform.position = grab.pizzaTransform.transform.position;
        grab.pizza.SwitchState(grab.pizza.readyToCookState);
    }
}