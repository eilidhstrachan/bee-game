using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDialogue : MonoBehaviour
{

    private bool playerInRange;
    public string NPCName;
    public TextMeshProUGUI nametagText;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // Start is called before the first frame update
    void Awake()
    {
        nametagText.text = "";
        playerInRange = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsRunning)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                nametagText.text = NPCName;
                DialogueManager.GetInstance().StartDialogue(inkJSON);
            }
            else
            {
                nametagText.text = "";
            }
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
