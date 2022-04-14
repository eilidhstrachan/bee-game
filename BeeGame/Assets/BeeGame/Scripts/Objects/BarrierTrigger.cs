using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrierTrigger : MonoBehaviour
{
    public int requiredPoints;
    public GameObject prompt;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI points;

    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    void Awake()
    {
        this.gameObject.SetActive(true);
        prompt.SetActive(false);
        playerInRange = false;
    }

    void Update()
    {
        if (playerInRange == true)
        {
            Debug.Log("Points = "+ int.Parse(points.text));
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                tagText.text = name;
                DialogueManager.GetInstance().StartDialogue(inkJSON);
                prompt.SetActive(false);
            }
        }
        else
        {
            prompt.SetActive(false);
        }

        if (int.Parse(points.text) >= requiredPoints)
        {
            this.gameObject.SetActive(false);
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
