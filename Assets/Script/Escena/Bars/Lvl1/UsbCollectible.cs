using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbCollectible : MonoBehaviour
{
    [SerializeField] private float UsbValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<UsbPlayer>().AddUsb(UsbValue);
            SoundManager.PlaySound("Usb");
            Destroy(gameObject);
        }

    }
}
