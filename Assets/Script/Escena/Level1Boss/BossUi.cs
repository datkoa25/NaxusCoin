using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUi : MonoBehaviour
{

    public GameObject BossPanel;
    public GameObject Muros;
    public GameObject Jefe;
    public GameObject usb;
    public GameObject Dialogue;
    public GameObject Letrero;
    public static BossUi instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BossPanel.SetActive(false);
        Muros .SetActive(false);
        Jefe.SetActive(false);
        usb.SetActive(false);
        Dialogue.SetActive(false);
        Letrero.SetActive(false);
    }

   public void BossActivator()
    {
        BossPanel.SetActive(true);
        Muros.SetActive(true);
        Jefe.SetActive(true);
        SoundManager.PlaySound("BossAppearence");
    }


    public void Deactivator()
    {
        BossPanel.SetActive(false);
        Muros.SetActive(false);
        usb.SetActive(true);
        Letrero.SetActive(true);
        Dialogue.SetActive(true);
    }
}
