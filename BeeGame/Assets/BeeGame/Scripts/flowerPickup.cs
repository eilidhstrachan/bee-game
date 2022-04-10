using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class flowerPickup : MonoBehaviour
{
    //public Image inventoryItem; test code
    //public Sprite flowerSprite;
    public GameObject bookSpace;
    public GameObject bookButton;
    public GameObject flower;
    public GameObject prompt;

    public AudioClip soundEffect;

    public bool playerInRange;

 

    // Start is called before the first frame update
    void Start()
    { 

        if (prompt.activeInHierarchy)
        {
            prompt.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (playerInRange == true && Input.GetKeyDown(KeyCode.Space))
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                flower.SetActive(false);
                prompt.SetActive(false);
                bookSpace.SetActive(false);
                bookButton.SetActive(true);

                // inventoryItem.sprite = flowerSprite; test code
            }
        
    }

    // when player is within the range of the 2D collider trigger, sets playerInRange to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");

            prompt.SetActive(true); // shows prompt UI item 
        }
    }

    // when player leaves the range of the 2D collider trigger, sets playerInRange to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false; 
            Debug.Log("player out of range");

            prompt.SetActive(false); // hides the prompt UI item
        }
    }


}
