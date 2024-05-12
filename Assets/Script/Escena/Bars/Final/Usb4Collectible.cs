using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usb4Collectible : MonoBehaviour
{
    [SerializeField] private float UsbValue;
    public float duration = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Usb4Player>().AddUsb(UsbValue);
            SoundManager.PlaySound("PowerUp");
            StartCoroutine(PickUp(collision));
            
        }

    }

    IEnumerator PickUp(Collider2D collision)
    {
        Attack stats = collision.GetComponent<Attack>();
        stats.Daamage = 10;
        collision.GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        collision.GetComponent<SpriteRenderer>().color = Color.white;
        stats.Daamage = 1;

        

        Destroy(gameObject);
    }
}
