using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour
{

    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public BoxCollider boxHit;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxHit = GetComponent<BoxCollider>();
    }
}
