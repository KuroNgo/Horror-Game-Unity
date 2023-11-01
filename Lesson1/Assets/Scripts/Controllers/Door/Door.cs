using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool inReach;

    private bool isOn = false;
    void Start()
    {
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
        if (inReach && Input.GetKeyDown(KeyCode.F) && isOn == true)
        {
            DoorOpens();
        }
        else if (inReach && Input.GetKeyDown(KeyCode.F) && isOn == false)
        {
            DoorClose();
        }
    }

    void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
        isOn = false;
    }
    void DoorClose()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        isOn = true;
    }
}
