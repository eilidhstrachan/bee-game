using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

    /*
     * FlowerPickup deals with hiding flower objects once they have been picked up by the player, adding them to 
     * the scrapbook, and saving whether a flower has been picked up or not to the game data file.
     */
    public class FlowerPickup : MonoBehaviour, IDataManagement
    {
        //public Image inventoryItem; test code
        //public Sprite flowerSprite;

        public static event Action OnFlowerPickup; // this action is used in the PickupAudioPlayer class

        // variables used in the FlowerPickup script to be shown in the inspector
        public int flowerID;
        
        public GameObject bookSpace;
        public GameObject bookButton;
        public GameObject flower;
        public GameObject prompt;
        public GameObject encyclopaedia;

        public bool playerInRange;
        public bool isPickedUp = false;

        // Start is called before the first frame update
        void Start()
        {
            // sets the spacebar icon prompt to be hidden
            if (prompt.activeInHierarchy)
            {
                prompt.SetActive(false);
            }

        }

        // Update is called once per frame
        void Update()
        {
            // when the player is in range and they have also pressed the space bar to interact with the object
            if (playerInRange == true && Input.GetKeyDown(KeyCode.Space))
            {
                // invokes the OnFlowerPickup action for the PickupAudioPlayer class observers to play the sound effect
                OnFlowerPickup?.Invoke(); 

                // hides the flower object in the world as it has now been picked up, makes the corresponding book icon active and hides the placeholder icon
                isPickedUp = true;
                flower.SetActive(false);
                prompt.SetActive(false);
                bookSpace.SetActive(false);
                bookButton.SetActive(true);
                encyclopaedia.GetComponent<CollectionManager>().AddFlowers(); // calls add flowers in the CollectionManager script

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

    // implements IDataManagement so that flower data can be loaded between scenes and if the player loads a previous save file
    public void LoadData(GameData data)
    {
        // reads in the flowers dictionary values
        data.flowers.TryGetValue(flowerID, out isPickedUp);
        if (isPickedUp == true)
        {
            // if flower has been previously picked up, make sure it is set to be inactive & have its scrapbook icon visible
            flower.SetActive(false);
            bookSpace.SetActive(false);
            bookButton.SetActive(true);
        }
        else
        {
            // if flower has not been previously picked up, make sure it is set to be active & have its scrapbook icon hidden
            flower.SetActive(true);
            bookSpace.SetActive(true);
            bookButton.SetActive(false);
        }
    }


    // implements IDataManagement so that flower data can be saved between scenes 
    public void SaveData(GameData data)
    {
        // if there is already save data for a flower with the same flowerID, remove that one
        if (data.flowers.ContainsKey(flowerID))
        {
            data.flowers.Remove(flowerID);
        }

        data.flowers.Add(flowerID, isPickedUp); // adds current flower data to gamedata file
    }
}

