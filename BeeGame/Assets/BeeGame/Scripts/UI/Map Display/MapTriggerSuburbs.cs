using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * This script handles the trigger for the Suburbs collider
 */
public class MapTriggerSuburbs : MonoBehaviour
{
    public static event Action OnSuburbsEnter;

    public bool playerInRange;

    // when the player enters the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnSuburbsEnter?.Invoke(); // invokes the OnSuburbsEnter action
            playerInRange = true;
            Debug.Log("player in range");
        }
    }

    // when the player exits the collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }
}
