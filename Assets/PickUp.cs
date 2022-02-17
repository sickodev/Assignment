using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickupDistance = 2.0f;
    public float holdDistance = 2.0f;
    public LayerMask pickupMask;

    private bool isHoldingSomething = false;
    private GameObject heldObject;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if (!isHoldingSomething)
        {
            //We are not holding an object
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, pickupDistance, pickupMask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hitInfo.collider.transform.parent = transform.parent;
                    hitInfo.rigidbody.isKinematic = true;

                    Vector3 newPosition = transform.position;
                    newPosition += transform.forward * holdDistance;
                    hitInfo.collider.transform.position = newPosition;

                    heldObject = hitInfo.collider.gameObject;
                    isHoldingSomething = true;
                }
            }
        }
        else
        {
            //We are holding an object
            Vector3 newPosition = transform.position;
            newPosition += transform.forward * holdDistance;
            heldObject.transform.position = newPosition;

            if (Input.GetMouseButtonDown(0))
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.transform.parent = null;
                heldObject = null;
                isHoldingSomething = false;
            }
        }

    }
}
