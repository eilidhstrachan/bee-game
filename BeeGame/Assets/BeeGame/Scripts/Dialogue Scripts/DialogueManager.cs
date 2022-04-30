using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/* 
 * the base for the code in this script was made with the help of https://www.youtube.com/watch?v=vY0Sk93YUhA by Trevor Mock and then built upon by myself
 * the DialogueManager class mostly just deals with displaying dialogue to the UI from the Ink dialogue files.
 */
public class DialogueManager : MonoBehaviour
{
    // variables relating to showing/hiding the map display
    [SerializeField] private GameObject mapDisplay;
    [SerializeField] private Toggle mapToggle;

    // variables relating to the dialogue display UI
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject continueText;
    [SerializeField] private GameObject nametag;

    // variables relating to displaying dialogue choices
    [Header("Dialogue Choices UI")]
    [SerializeField] private TextMeshProUGUI[] choiceUIText;
    [SerializeField] private GameObject[] choices;

    private Story currentItem;

    // singleton, instance of the DialogueManager class
    private static DialogueManager instance;

    private bool makingChoice;
    private bool choiceMade;

    // variable to store the values received from Ink files that have choices 
    private DialogueValues dialogueValues;

    public bool dialogueIsRunning { get; private set; }

    private void Awake()
    {
        // warns that there's already an instance of DialogueManager active
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Dialogue Manager active in this scene.");
        }

        instance = this;

        dialogueValues = new DialogueValues();
    }

    // returns the DialogueManager instance
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // initialises all the related dialogue variables, hides the UI objects
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
        // hides the click to continue text when choices are active so that the player knows to click on a choice
        if (choices[0].activeInHierarchy == true)
        {
            continueText.SetActive(false);
            makingChoice = true;
        }
        else
        {
            continueText.SetActive(true);
            makingChoice = false;
        }

        // if there isn't any dialogue currently playing, return
        if (!dialogueIsRunning)
        {
            //Debug.Log("Returning"); used for testing
            return;
        }

        // code added so that mouse button can be used to click on the choice UI buttons when choices are active
        if (makingChoice == false)
        {
            //Debug.Log("not making choice"); used for testing
            if ((Input.GetMouseButtonDown(0)) && dialogueIsRunning == true)
            {
                // if a choice has been made, continue the story
                choiceMade = true;
                ContinueStory();
            }
        }
        
    }

    // starts running the dialogue from the ink file
    public void StartDialogue(TextAsset inkJSON)
    {
        currentItem = new Story(inkJSON.text);
        dialogueIsRunning = true;
        dialogueBox.SetActive(true);
        nametag.SetActive(true);
        continueText.SetActive(true);

        // hides the map display 
        if (mapDisplay.activeInHierarchy == true)
        {
            mapDisplay.SetActive(false);
        }

        // enables the dialogueValues observer for the current story item
        dialogueValues.ObserverEnabled(currentItem);

        ContinueStory();
    }

    // stops running the dialogue
    private void StopDialogue()
    {
        dialogueIsRunning = false;
        Debug.Log("stop dialogue is being called!");
        Debug.Log(dialogueIsRunning);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        nametag.SetActive(false);

        // if the map display was showing before dialogue started playing, set it to be active again
        if (mapToggle.isOn == true)
        {
            mapDisplay.SetActive(true);
        }

        // disables the dialogueValues observer
        dialogueValues.ObserverDisabled(currentItem);
    }

    // displays the Ink file dialogue until it reaches the end of the the file
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
            // stops displaying dialogue once the end of the file is reached
            StopDialogue();
        }
    }

    // displays the choices from the Ink file with the UI choices objects
    private void ShowChoices()
    {
        List<Choice> activeChoices = currentItem.currentChoices;

        // error message for if there are more than 2 choices in the Ink file
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

    // code for Unity to have a first choice automatically selected
    private IEnumerator AutoSelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    // processes the player's choice and displays the related dialogue from the Ink file for that choice
    public void SelectChoice(int choiceIndex)
    {
        currentItem.ChooseChoiceIndex(choiceIndex);
        choiceMade = true;
        ContinueStory();
    }

}
