using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject nametag;

    private Story currentItem;

    private static DialogueManager instance;

    public bool dialogueIsRunning;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Dialogue Manager active in this scene.");
        }

        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsRunning = false;
        dialogueBox.SetActive(false);
        nametag.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsRunning)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueStory();
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        currentItem = new Story(inkJSON.text);
        dialogueIsRunning = true;
        dialogueBox.SetActive(true);
        nametag.SetActive(true);

        //ContinueStory();
    }

    private void StopDialogue()
    {
        dialogueIsRunning = false;
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        nametag.SetActive(false);
    }

    private void ContinueStory()
    {
        if (currentItem.canContinue)
        {
            dialogueText.text = currentItem.Continue();
        }
        else
        {
            StopDialogue();
        }
    }


}
