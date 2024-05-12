using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoNivel2 : MonoBehaviour
{
    public GameObject NoUsb;

    private void Start()
    {
        NoUsb.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.tag == "Player")
            {
                Usb2Player stats = collider.GetComponent<Usb2Player>();
                if (stats.currentUsb >= 5f)
                {
                    SceneManager.LoadScene(4);
                }

                else
                {
                    NoUsb.SetActive(true);
                    StartCoroutine(Destruir());
                    Debug.Log("Not Usb");
                }

            }
        }
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSecondsRealtime(4.6f);
        Destroy(NoUsb);
    }
}
