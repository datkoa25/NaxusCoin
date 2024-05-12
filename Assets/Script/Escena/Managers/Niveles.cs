using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToDestroy", 3.5f);
    }

   public void WaitToDestroy()
    {
        Destroy(gameObject);
    }
}
