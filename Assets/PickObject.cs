using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public Vector2 posi;
    public Transform playerPickedUpPos;
    //public RayCasting casting;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitinfo;
        posi = Input.mousePosition;
        Vector3 origin = new Vector3(1f, 1f,1f);
        if(Physics.Raycast(origin,transform.forward,out hitinfo))
        {
            float zAxis = Mathf.Sqrt(Mathf.Pow((1f - hitinfo.point.z),2));

            if(hitinfo.collider.CompareTag("Bone"))
            {
                posi = hitinfo.transform.position;
                hitinfo.transform.position = new Vector3(posi.x, posi.y, zAxis);
            }
        }

        
    }
}
