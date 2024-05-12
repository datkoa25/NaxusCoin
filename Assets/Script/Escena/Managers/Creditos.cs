using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitForEnd", 20);
    }

    
   

    public void WaitForEnd()
    {
        SceneManager.LoadScene(1);
    }
}
