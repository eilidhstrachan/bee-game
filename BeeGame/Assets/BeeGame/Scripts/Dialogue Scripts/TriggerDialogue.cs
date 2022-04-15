using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// acts as a basic trigger for NPCs to start their dialogue. Incorporates some logic to decide which ink dialogue file the NPCs should use based on where the player is in the game
// such as by using the amount of puzzle points they have collected or the amount of flowers they have collected. 
public class TriggerDialogue : MonoBehaviour
{
    private bool playerInRange;
    public string NPCName;
    public TextMeshProUGUI nametagText;
    public GameObject prompt;
    public TextMeshProUGUI points;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON1;
    [SerializeField] private TextAsset inkJSON2;

    void Awake()
    {
        nametagText.text = "";
        prompt.SetActive(false);
        playerInRange = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsRunning)
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                nametagText.text = NPCName;
                if (int.Parse(points.text) == 0)
                {
                    DialogueManager.GetInstance().StartDialogue(inkJSON1);
                }
                else
                {
                    DialogueManager.GetInstance().StartDialogue(inkJSON2);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");
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

}
