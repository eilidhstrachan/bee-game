using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This class handles the area barriers and displaying their prompts and 
 * related dialogue.
 */
public class BarrierTrigger : MonoBehaviour
{
    // variables to show in the inspector
    public int requiredPoints;
    public GameObject prompt;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI points;

    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // sets the barrier to be active, and hides the keyboard key prompt
    void Awake()
    {
        this.gameObject.SetActive(true);
        prompt.SetActive(false);
        playerInRange = false;
    }

    void Update()
    {
        // if the player is in range of the barrier, display the prompt so they know they can interact with it
        if (playerInRange == true)
        {
            Debug.Log("Points = "+ int.Parse(points.text));
            prompt.SetActive(true);

            // if the player presses the F key
            if (Input.GetKeyDown(KeyCode.F))
            {
                // display the barrier dialogue and hide the prompt while it is playing
                tagText.text = name;
                DialogueManager.GetInstance().StartDialogue(inkJSON);
                prompt.SetActive(false);
            }
        }
        else
        {
            // while player is out of range, hide the prompt
            prompt.SetActive(false);
        }

        //if the player has enough points to progress to the next area, sets the barrier to not be active anymore
        if (int.Parse(points.text) >= requiredPoints)
        {
            this.gameObject.SetActive(false);
        }
    }

    // detects if the player enters the range of the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");
        }
    }

    // detects if the player exits the range of the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }

}
