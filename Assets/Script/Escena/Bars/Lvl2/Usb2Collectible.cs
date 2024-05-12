using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usb2Collectible : MonoBehaviour
{
    [SerializeField] private float UsbValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Usb2Player>().AddUsb(UsbValue);
            SoundManager.PlaySound("Usb");
            Destroy(gameObject);
        }

    }
}
