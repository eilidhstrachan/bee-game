using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject nametag;
    public TextMeshProUGUI nametagText;
    public string nameText;

    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // Start is called before the first frame update
    void Start()
    {
        if (nametag.activeInHierarchy)
        {
            nametag.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
        {
            if (nametag.activeInHierarchy)
            {
                nametag.SetActive(false);
            }
            else
            {
                nametag.SetActive(true);
                nametagText.text = nameText;
            }
            DialogueManager.GetInstance().StartDialogue(inkJSON);
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
            nametag.SetActive(false);
            Debug.Log("player out of range");
        }
    }
}
