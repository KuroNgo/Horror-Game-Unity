using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject openText;

    public GameObject showText;

    public AudioSource doorSound;

    public bool inReach;

    private bool isOn = false;
    void Start()
    {
        showText.SetActive(false);
        inReach = false;
        isOn = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && isOn == true )
        {
            DoorOpens();
        }
        else if (inReach && Input.GetButtonDown("Interact") && isOn == false)
        {
            DoorClose();
        }
    }

    void DoorOpens()
    {
        showText.SetActive(true);
        isOn = false;
    }
    void DoorClose()
    {
        showText.SetActive(false);
        isOn = true;
    }
}
