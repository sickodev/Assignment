using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpRange = 10f;
    public float moveForce = 250f;
    public Transform holdParent;
    private GameObject heldObject;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if (heldObject == null)
            {
                RaycastHit hitinfo;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, pickUpRange))
                {
                    PickUpObj(hitinfo.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    { 
        if(Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = holdParent.transform.position - heldObject.transform.position;
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObj(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObject = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObject.transform.parent = null;
        heldObject = null;
    }
}
