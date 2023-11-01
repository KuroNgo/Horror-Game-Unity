using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public GameObject showText;

    public GameObject boxFlash;

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
            if (boxFlash.activeInHierarchy == true)
            {
                inReach = true;
                openText.SetActive(true);
            }
            else
            {
                showText.SetActive(true);
                inReach = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Reach")
        {
            if (boxFlash.activeInHierarchy == true)
            {
                inReach = false;
                openText.SetActive(false);
            }
            else
            {
                inReach = false;
                showText.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (inReach && Input.GetKeyDown(KeyCode.F) && isOn == true && boxFlash.activeInHierarchy == true)
        {
            DoorOpens();
        }
        else if (inReach && Input.GetKeyDown(KeyCode.F) && isOn == false && boxFlash.activeInHierarchy == true)
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
        doorSound.Play();

        isOn = true;
    }
}
