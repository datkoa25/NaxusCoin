using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToDestroy", 38f);
    }

    public void WaitToDestroy()
    {
        SceneManager.LoadScene(5);
    }
}