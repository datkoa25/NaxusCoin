using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private AudioSource lvlmusic;
    [SerializeField] private GameObject panelPausa;

    private void Start()
    {
        lvlmusic = GetComponent<AudioSource>();
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            SoundManager.PlaySound("PauseIn");
            panelPausa.SetActive(true);
        }

        
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        lvlmusic.Pause();
        
    }

    public void Resumir()
    {
        Time.timeScale = 1f;
        lvlmusic.UnPause();
        SoundManager.PlaySound("PauseOut");
        panelPausa.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Quitamos la aplicacion");
        Application.Quit();
    }


}
