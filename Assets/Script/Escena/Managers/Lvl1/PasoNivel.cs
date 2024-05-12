using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoNivel : MonoBehaviour
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
            UsbPlayer stats = collider.GetComponent<UsbPlayer>();
            if(stats.currentUsb >= 2f)
            {
                SceneManager.LoadScene(3);
            }

            else
            {
                NoUsb.SetActive(true);
                StartCoroutine(Destruir());
                Debug.Log("Not Usb");
            }
            
        }
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSecondsRealtime(4.6f);
        Destroy(NoUsb);
    }
}
