using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BeeManager class makes bee and flower game objects in the garden area active as flowers are collected by the player
 * each collectable flower has a corresponding bee and garden flower game object that will appear in the garden once
 * it has been collected.
 */
public class BeeManager : MonoBehaviour
{
    // lists of all the game objects to be shown in the Unity inspector
    public List<GameObject> bees;
    public List<GameObject> flowerItems;
    public List<GameObject> flowerObjects;

    public void Awake()
    {
        // sets all bee objects to be hidden at the start of the game
        for (int i = 0; i < bees.Count; i++)
        {
            bees[i].SetActive(false);
        }

        // sets all garden flowers to be hidden at the start of the game
        for (int i = 0; i < flowerObjects.Count; i++)
        {
            flowerObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for each collectable flower object in the list
        for (int i = 0; i < flowerItems.Count; i++)
        { 
            // if the collectable flower is no longer active in the game, meaning it has been picked up
            if (flowerItems[i].activeInHierarchy == false)
            {
                // sets the corresponding garden flower and bee objects to be active
                bees[i].SetActive(true);
                flowerObjects[i].SetActive(true);
            }
        }
    }
}
