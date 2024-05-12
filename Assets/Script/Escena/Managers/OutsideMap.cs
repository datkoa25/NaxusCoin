using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<HealthPlayer>().TakeDamage(11);
        }
    }
}
