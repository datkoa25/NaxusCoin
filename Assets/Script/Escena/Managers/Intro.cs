using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToDestroy", 61f);
    }

   public void WaitToDestroy()
    {
        SceneManager.LoadScene(1);
    }
}
