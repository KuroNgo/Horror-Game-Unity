using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioSource footstepswalk, footstepsprint;
    public bool sprinting;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprinting = true;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprinting = false;
            }
            if (sprinting == true)
            {
                footstepswalk.enabled = false;
                footstepsprint.enabled = true;
            }
            if (sprinting == false)
            {
                footstepswalk.enabled = true;
                footstepsprint.enabled = false;
            }
        }
        else
        {
            footstepswalk.enabled = false;
            footstepsprint.enabled = false;
            sprinting = false;
        }
    }
}
