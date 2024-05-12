using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public void SpawnNewPowerUp()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(7);
        GameObject nb = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], this.transform) as GameObject;
        nb.transform.localPosition = new Vector3(Random.Range(-8, 8), 0, 0);
    }
}
