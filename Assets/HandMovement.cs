using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public GameObject hand;
    private bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isClicked == false)
            {
                StartCoroutine(MoveHand());
            }
        }
    }

    IEnumerator MoveHand()
    {
        isClicked = true;
        hand.GetComponent<Animator>().Play("Move");
        yield return new WaitForSeconds(0.1f);
        hand.GetComponent<Animator>().Play("New State");
        isClicked = false;
    }
}
