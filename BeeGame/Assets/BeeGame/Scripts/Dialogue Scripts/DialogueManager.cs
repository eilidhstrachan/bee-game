using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


// the base for this code was made with the help of https://www.youtube.com/watch?v=vY0Sk93YUhA by Trevor Mock and then built upon by myself
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject nametag;

    [Header("Dialogue Choices UI")]
    [SerializeField] private TextMeshProUGUI[] choiceUIText;
    [SerializeField] private GameObject[] choices;

    private Story currentItem;

    private static DialogueManager instance;

    private bool makingChoice;
    private bool choiceMade;

    private DialogueValues dialogueValues;

    public bool dialogueIsRunning { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Dialogue Manager active in this scene.");
        }

        instance = this;

        dialogueValues = new DialogueValues();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        int index = 0;

        makingChoice = false;
        choiceMade = false;
        dialogueIsRunning = false;
        dialogueBox.SetActive(false);
        nametag.SetActive(false);

        choiceUIText = new TextMeshProUGUI[choices.Length];

        foreach (GameObject choice in choices)
        {
            choiceUIText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }    
    }

    private void Update()
    {
        if (choices[0].activeInHierarchy == true)
        {
            makingChoice = true;
        }
        else
        {
            makingChoice = false;
        }

        if (!dialogueIsRunning)
        {
            //Debug.Log("Returning");
            return;
        }
        
        // code added so that mouse button can be used to click on the choice UI buttons when choices are active
        if (makingChoice == false)
        {
            //Debug.Log("not making choice");
            if ((Input.GetMouseButtonDown(0)) && dialogueIsRunning == true)
            {
                ContinueStory();
            }
        }
        else
        {
            //Debug.Log("making choice");
            if (choiceMade == true)
            {
                Debug.Log("Choice is made");
                //ContinueStory();
                /*
                if (Input.GetKeyDown(KeyCode.Space) && dialogueIsRunning == true)
                {
                    ContinueStory();
                }*/
            }
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        currentItem = new Story(inkJSON.text);
        dialogueIsRunning = true;
        dialogueBox.SetActive(true);
        nametag.SetActive(true);

        dialogueValues.ObserverEnabled(currentItem);

        ContinueStory();
    }

    private void StopDialogue()
    {
        dialogueIsRunning = false;
        Debug.Log("stop dialogue is being called!");
        Debug.Log(dialogueIsRunning);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        nametag.SetActive(false);

        dialogueValues.ObserverDisabled(currentItem);
    }

    private void ContinueStory()
    {
        if (currentItem.canContinue)
        {
            Debug.Log(dialogueIsRunning);
            dialogueText.text = currentItem.Continue();
            ShowChoices();
        }
        else
        {
            StopDialogue();
        }
    }

    private void ShowChoices()
    {
        List<Choice> activeChoices = currentItem.currentChoices;

        if (activeChoices.Count > choices.Length)
        {
            Debug.LogError("There are more choices than UI choice buttons available. The number of attempted choices is: " + activeChoices);
        }

        int index = 0;
        foreach(Choice choice in activeChoices)
        {
            choices[index].gameObject.SetActive(true);
            choiceUIText[index].text = choice.text;
            index++;
        }

        for (int count = index; count < choices.Length; count++)
        {
            choices[count].gameObject.SetActive(false);
        }

        StartCoroutine(AutoSelectFirstChoice());
    }

    private IEnumerator AutoSelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void SelectChoice(int choiceIndex)
    {
        currentItem.ChooseChoiceIndex(choiceIndex);
        choiceMade = true;
        ContinueStory();
    }

}
