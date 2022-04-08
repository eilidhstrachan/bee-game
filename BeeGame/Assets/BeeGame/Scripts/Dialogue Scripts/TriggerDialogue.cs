using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// the base for this code was made with the help of https://www.youtube.com/watch?v=vY0Sk93YUhA by Trevor Mock and then built upon by myself
public class TriggerDialogue : MonoBehaviour
{
    private bool playerInRange;
    public string NPCName;
    public TextMeshProUGUI nametagText;
    public GameObject prompt;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // Start is called before the first frame update
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
                DialogueManager.GetInstance().StartDialogue(inkJSON);
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
