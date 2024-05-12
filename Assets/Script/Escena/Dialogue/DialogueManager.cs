using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private AudioClip tipeo;
    [SerializeField] private int charsToPlaySound;
    private static DialogueManager instance;
    private Story currentStory;
    private Coroutine displayLineCoroutine;
    private AudioSource audioSource;

    public bool DialogueIsPlaying { get; private set; }

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    
    private bool canContinueToNextLine = false;
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = tipeo;

    }
    private void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }

     
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Time.timeScale = 0f;
        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
        
       


    }

    private void ExitDialogueMode()
    {
        
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        Time.timeScale = 1f;
    }

   

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine= StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        canContinueToNextLine = false;
        int charIndex = 0;

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetKey(KeyCode.Return))
            {
                dialogueText.text = line;
                break;
            }
           
            dialogueText.text += letter;
            if (charIndex % charsToPlaySound == 0)
            {
                audioSource.Play();
            }

            charIndex++;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        canContinueToNextLine = true;
    }

    private void HandleTags(List<string>currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
           
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;

                
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled" + tag);
                        break;
            }
        }
    }
}
