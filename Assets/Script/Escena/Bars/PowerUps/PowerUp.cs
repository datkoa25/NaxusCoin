using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float duration = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySound("PowerUp");
            StartCoroutine(PickUp(collision));
        }
    }

    IEnumerator PickUp(Collider2D collision)
    {
        Attack stats = collision.GetComponent<Attack>();
        stats.Daamage = 5;
        collision.GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        collision.GetComponent<SpriteRenderer>().color = Color.white;
        stats.Daamage = 1;
        
        GameObject.Find("SpawnPoint2").GetComponent<Spawn2>().SpawnNewPowerUp();

        Destroy(gameObject);
    }

   
}
