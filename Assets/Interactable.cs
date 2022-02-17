using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform dest;
    private RayCasting casting;
    [SerializeField]
    private float velocity;


    public void OnMouseDown()
    {
        
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = dest.position;
        this.transform.parent = dest.parent;
        //if(Input.GetAxis("MouseScrollWheel")>0f)
        {
           // this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,this.transform.position.z*velocity*Time.deltaTime);
        }
        //else if(Input.GetAxis("MouseScrollWheel")<0f)
        {
            //transform.position.z *= -velocity
        }
    }

    public void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = false;
        
    }
}
