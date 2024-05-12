using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject VisualCue;


    
    [SerializeField] private TextAsset inkJSON;

    private bool PlayerInRange;
    private void Awake()
    {
        PlayerInRange = false;
        VisualCue.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInRange && !DialogueManager.GetInstance().DialogueIsPlaying)
        {
            VisualCue.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            VisualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
}
