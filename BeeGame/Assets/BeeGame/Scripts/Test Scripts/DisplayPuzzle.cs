using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayPuzzle : MonoBehaviour
{
    private bool playerInRange;
    public string sceneName;
    public GameObject prompt;

    private void Start()
    {
        playerInRange = false;
        prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true)
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                SaveDataManager.instance.SaveGame();
                SceneManager.LoadScene(sceneName);
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
