using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
   public void APQuit()
    {
        Debug.Log("Cerramos Aplicacion");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    public void Restart2Nivel()
    {
        SceneManager.LoadScene(3);
    }

    public void Restart3Nivel()
    {
        SceneManager.LoadScene(4);
    }

    public void RestartNivelFinal()
    {
        SceneManager.LoadScene(5);
    }
}
