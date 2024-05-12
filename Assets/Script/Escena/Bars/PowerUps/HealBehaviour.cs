using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("heal");
            SoundManager.PlaySound("Heart");
            collision.GetComponent<StatusEffectManager>().ApplyHeal(5);
            Destroy(gameObject);
            GameObject.Find("SpawnPoint").GetComponent<SpawnScript>().SpawnNewPowerUp();
            
        }
    }
}
