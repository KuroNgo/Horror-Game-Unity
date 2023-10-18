using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject inttext, lightSwitch;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator swtichAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //lightSwitchSound.Play();
                swtichAnim.ResetTrigger("press");
                swtichAnim.SetTrigger("press");
            }

            if (toggle == false)
            {
                lightSwitch.SetActive(false);
                lightBulb.material = offlight;
            }

            if (toggle == true)
            {
                lightSwitch.SetActive(true);
                lightBulb.material = onlight;
            }
        }


    }
}
