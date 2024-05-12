using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Usb4Bar : MonoBehaviour
{
    [SerializeField] private Usb4Player usbPlayer1;
    [SerializeField] private Image totalUsbBar;
    [SerializeField] private Image currentUsbBar;
    // Start is called before the first frame update
    void Start()
    {
        totalUsbBar.fillAmount = usbPlayer1.currentUsb / 10;

    }

    // Update is called once per frame
    void Update()
    {
        currentUsbBar.fillAmount = usbPlayer1.currentUsb / 10;

    }
}
