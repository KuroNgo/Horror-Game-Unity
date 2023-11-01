using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlash : MonoBehaviour
{

    public GameObject flashOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource pickUpSound;
    public bool inReach;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach") 
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    } 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            pickUpSound.Play();
            flashOB.SetActive(false);
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }
    }
}
