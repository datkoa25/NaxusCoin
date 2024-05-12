using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private GameObject options;
    [SerializeField] private GameObject Menu;
    [SerializeField] private TextMeshProUGUI volumetextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject volumeGO;
    [SerializeField] private GameObject controles;
   public void ButtonStart()
    {
        SoundManager.PlaySound("MenuSelect");
        SceneManager.LoadScene(7);
    }

    public void ButtonQuit()
    {
        SoundManager.PlaySound("MenuSelect");
        Debug.Log("Quitamos la aplicacion");
        Application.Quit();
    }

    public void InstructionsB()
    {
        SoundManager.PlaySound("MenuSelect");
        controles.SetActive(true);
    }

    public void ButtonOptions()
    {
        SoundManager.PlaySound("MenuSelect");
        options.SetActive(true);
        Menu.SetActive(false);
        
    }

    public void Back()
    {
        SoundManager.PlaySound("MenuSelect");
        options.SetActive(false);
        Menu.SetActive(true);

    }
    public void Volume()
    {
        SoundManager.PlaySound("MenuSelect");
        volumeGO.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumetextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        SoundManager.PlaySound("MenuSelect");
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    

}
