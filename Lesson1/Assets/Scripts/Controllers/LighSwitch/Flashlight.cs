using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject boxFlash;
    public GameObject flash;

    public AudioSource flashSound;
    private bool isOn = false;

    void Start()
    {
        flashlight.SetActive(isOn);
    }

    void Update()
    {
        if (boxFlash.activeInHierarchy == true && flash.activeInHierarchy == true && Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn; // Chuyển đổi trạng thái đèn pin
            flashSound.Play();
            flashlight.SetActive(isOn); // Bật hoặc tắt đèn pin dựa trên trạng thái mới
        }
        else if (flash.activeInHierarchy == false)
        {
            isOn = false;
            flashlight.SetActive(false);
        }
    }
}
