using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapTriggerVillage : MonoBehaviour
{
    public static event Action OnVillageEnter;

    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnVillageEnter?.Invoke();
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
