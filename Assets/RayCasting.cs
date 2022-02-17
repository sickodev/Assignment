using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class RayCasting : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 10f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    public Text display;
    public RaycastHit hit;

    public LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        display.enabled = false;
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {

        fireTimer += Time.deltaTime;

        fireTimer = 0;
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit,gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            //Destroy(hit.transform.gameObject);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        }
        StartCoroutine(ShootLaser());

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.CompareTag("Bone"))
            {
                display.text = hit.transform.name;
                display.enabled = true;
                gunRange = hit.transform.position.z;

            }
            else
            {
                display.enabled = false;
            }
        }
        if (hit.collider.CompareTag("Bone"))
        {
            laserLine.SetColors(start: Color.white, end: Color.white);
        }
        else
        {
            laserLine.SetColors(start: Color.red, end: Color.red);
        }

        IEnumerator ShootLaser()
        {
            laserLine.enabled = true;
            yield return new WaitForSeconds(laserDuration);
        }

    }
}
