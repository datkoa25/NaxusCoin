using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFinal : MonoBehaviour
{
   
    [SerializeField] private float healthValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthPlayer>().AddHealth(healthValue);
            SoundManager.PlaySound("Heart");
            Destroy(gameObject);
            GameObject.Find("SpawnPoint").GetComponent<SpawnScript>().SpawnNewPowerUp();
            


        }
    }
}