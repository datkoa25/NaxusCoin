using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToDestroy", 19f);
    }

    public void WaitToDestroy()
    {
        SceneManager.LoadScene(2);
    }
}
