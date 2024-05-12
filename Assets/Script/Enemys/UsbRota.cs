using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbRota : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<StatusEffectManager>().ApplyBurn(5);
            Destroy(gameObject);
        }
    }
}
