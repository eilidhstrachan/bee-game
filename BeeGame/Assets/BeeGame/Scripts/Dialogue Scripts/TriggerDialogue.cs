using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// acts as a basic trigger for NPCs to start their dialogue. Incorporates some logic to decide which ink dialogue file the NPCs should use based on where the player is in the game
// such as by using the amount of puzzle points they have collected or the amount of flowers they have collected. 
public class TriggerDialogue : MonoBehaviour, IDataManagement
{
    //public static event Action OnPointsIncreased;

    public int npcID;
    public string NPCName;
    private bool playerInRange;
    public TextMeshProUGUI nametagText;
    public GameObject prompt;
    public TextMeshProUGUI pointsDisplay;
    public bool introsHeard;

    public int npcPoints;
    //private int tempPoints;
    //public GameObject displayManager;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkIntro;
    [SerializeField] private TextAsset inkPart1;
    [SerializeField] private TextAsset inkPart2;


    void Awake()
    {
        nametagText.text = "";
        prompt.SetActive(false);
        playerInRange = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(int.Parse(pointsDisplay.text));

        //if (int.Parse(pointsDisplay.text) > npcPoints)
        //{ 
        //Debug.Log("Invoking OnPointsIncreased");
        //OnPointsIncreased?.Invoke();
        //}

        DialogueLogic();

    }

    //int.Parse(pointsDisplay.text)
    private void DialogueLogic()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsRunning)
        {
            Debug.Log("npc points is equal to = " + npcPoints);
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                nametagText.text = NPCName;
                if (introsHeard == false)
                {
                    //DialogueManager.GetInstance().StartDialogue(inkIntro);
                    IntroStoryLogic();
                }
                else if (npcPoints < 2 && introsHeard == true)
                {
                    DialogueManager.GetInstance().StartDialogue(inkPart1);
                }
                else
                {
                    DialogueManager.GetInstance().StartDialogue(inkPart2);
                }
                prompt.SetActive(false);
            }
            else
            {
                nametagText.text = "";
            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }

    private void IntroStoryLogic()
    {
        DialogueManager.GetInstance().StartDialogue(inkIntro);
        introsHeard = true;
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

    /*
    public void AddPoints()
    {
        Debug.Log(pointsDisplay.GetComponentInParent<PointsDisplay>().GetPoints());
    }

    private void OnEnable()
    {
        //TriggerDialogue.OnPointsIncreased += AddStoryPoints;
        PointsDisplay.OnPointsIncreased += AddPoints;
    }

    private void OnDisable()
    {
        //TriggerDialogue.OnPointsIncreased -= AddStoryPoints;
        PointsDisplay.OnPointsIncreased += AddPoints;
    }*/

}
