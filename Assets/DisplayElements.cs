using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayElements : MonoBehaviour
{
    public GameObject help;
    public GameObject ui;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            help.SetActive(true);
            ui.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            help.SetActive(false);
            ui.SetActive(true);
        }

    }
}
