using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCStateManager : MonoBehaviour, IDataManagement
{
    public int npcID;
    public string NPCName;
    public bool playerInRange;
    public TextMeshProUGUI nametagText;
    public GameObject prompt;
    public TextMeshProUGUI pointsDisplay;
    public bool introsHeard;

    public int npcPoints;

    public bool hasPuzzle;

    [Header("Ink JSON")]
    public TextAsset inkIntro;
    public TextAsset inkPart1;
    public TextAsset inkPart2;
    public TextAsset puzzleDialogue;

    NPCBaseState currentState;
    public NPCIdleState IdleState = new NPCIdleState();
    public NPCDialogueState DialogueState = new NPCDialogueState();
    public NPCIntroState IntroState = new NPCIntroState();
    public NPCPart1State Part1State = new NPCPart1State();
    public NPCPart2State Part2State = new NPCPart2State();
    public NPCPuzzleState PuzzleState = new NPCPuzzleState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;

        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(NPCBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");
            //Debug.Log("NPC points = "+ npcPoints);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }

    public void LoadData(GameData data)
    {
        data.npcIntro.TryGetValue(npcID, out introsHeard);
        this.npcPoints = data.puzzlePoints;

    }

    public void SaveData(GameData data)
    {
        if (data.npcIntro.ContainsKey(npcID))
        {
            data.npcIntro.Remove(npcID);
        }

        data.npcIntro.Add(npcID, introsHeard);
    }
}
