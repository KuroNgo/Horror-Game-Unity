using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject flash;
    public GameObject boxFlash;

    void Start()
    {
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && boxFlash.activeInHierarchy == true)
        {
            flash.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && boxFlash.activeInHierarchy == true)
        {
            flash.SetActive(false);
        }
    }
}
