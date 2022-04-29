using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * This class deals with displaying dialogue for certain world objects.
 */
public class ObjectTrigger : MonoBehaviour
{
    // variables to be shown in the inspector
    public GameObject prompt;
    public TextMeshProUGUI tagText;

    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset objectText; // text to display

    // sets the object to be active, hides the prompt
    void Awake()
    {
        this.gameObject.SetActive(true);
        prompt.SetActive(false);
        playerInRange = false;
    }

    void Update()
    {
        // if the player is in range of the object, shows the prompt
        if (playerInRange == true)
        {
            prompt.SetActive(true);

            // if the player presses F, displays the object text
            if (Input.GetKeyDown(KeyCode.F))
            {
                tagText.text = name;
                DialogueManager.GetInstance().StartDialogue(objectText);
                prompt.SetActive(false);
            }
        }
        else
        {
            // if the player is out of range, hides the prompt
            prompt.SetActive(false);
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
