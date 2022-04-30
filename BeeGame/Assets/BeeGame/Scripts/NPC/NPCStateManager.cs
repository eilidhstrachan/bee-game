using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This script contains all the methods for managing NPC state changes, and initiating the dialogue manager class to display
 * dialogue. Part of my main AI game concept.
 */
public class NPCStateManager : MonoBehaviour, IDataManagement
{
    // variables for all the related NPC data and game objects
    public int npcID;
    public string NPCName;
    public bool playerInRange;
    public TextMeshProUGUI nametagText;
    public GameObject prompt;
    public GameObject puzzlePrompt;
    public TextMeshProUGUI pointsDisplay;
    public bool introsHeard;
    public bool postPuzzleHeard;

    public int npcPoints;

    public bool hasPuzzle;
    public bool puzzleCompleted;
    public string scene = "";

    // all the dialogue Ink files to be shown in the inspector
    [Header("Ink JSON")]
    public TextAsset inkIntro;
    public TextAsset inkPart1;
    public TextAsset inkPart2;
    public TextAsset inkPart3;
    public TextAsset postPuzzle;
    public TextAsset puzzleDialogue;

    // initialises all the NPC state types
    NPCBaseState currentState;
    public NPCIdleState IdleState = new NPCIdleState();
    public NPCDialogueState DialogueState = new NPCDialogueState();
    public NPCIntroState IntroState = new NPCIntroState();
    public NPCPart1State Part1State = new NPCPart1State();
    public NPCPart2State Part2State = new NPCPart2State();
    public NPCPart3State Part3State = new NPCPart3State();
    public NPCPuzzleState PuzzleState = new NPCPuzzleState();
    public NPCActivePuzzle ActivePuzzle = new NPCActivePuzzle();
    public NPCPostPuzzleState PostPuzzle = new NPCPostPuzzleState();

    // Start is called before the first frame update
    void Start()
    {
        // sets the current state to be idle
        currentState = IdleState;

        // enters the current state
        currentState.EnterState(this);

        // hides the puzzle prompt
        puzzlePrompt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // if the NPC's puzzle has been completed, hasPuzzle is set to false so the Puzzle State can't be entered again
        if (puzzleCompleted == true)
        {
            hasPuzzle = false;
        }
        currentState.UpdateState(this); // updates the current state
    }

    // handles changing the NPC state
    public void ChangeState(NPCBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    // when the player is in range, set player in range to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");
            //Debug.Log("NPC points = "+ npcPoints); used for debugging
        }
    }

    // when the player is not in range, set player in range to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }

    // loads NPC data from the gamedata file
    public void LoadData(GameData data)
    {
        data.npcIntro.TryGetValue(npcID, out introsHeard);
        this.npcPoints = data.puzzlePoints;
        data.puzzles.TryGetValue(npcID, out puzzleCompleted);
        data.postPuzzle.TryGetValue(npcID, out postPuzzleHeard);
    }

    // saves the current NPC data to the gamedata 
    public void SaveData(GameData data)
    {
        if (data.npcIntro.ContainsKey(npcID))
        {
            data.npcIntro.Remove(npcID);
        }

        data.npcIntro.Add(npcID, introsHeard);

        if (data.postPuzzle.ContainsKey(npcID))
        {
            data.postPuzzle.Remove(npcID);
        }

        data.postPuzzle.Add(npcID, postPuzzleHeard);
    }
}
