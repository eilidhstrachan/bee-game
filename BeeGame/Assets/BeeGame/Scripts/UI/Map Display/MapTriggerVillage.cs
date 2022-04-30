using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * This script handles the trigger for the Village collider
 */
public class MapTriggerVillage : MonoBehaviour
{
    public static event Action OnVillageEnter;

    public bool playerInRange;

    // when the player enters the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnVillageEnter?.Invoke(); // invokes the OnVillageEnter action
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
