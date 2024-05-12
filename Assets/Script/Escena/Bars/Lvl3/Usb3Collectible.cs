using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usb3Collectible : MonoBehaviour
{
    [SerializeField] private float UsbValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Usb3Player>().AddUsb(UsbValue);
            SoundManager.PlaySound("Usb");
            Destroy(gameObject);
        }

    }
}
