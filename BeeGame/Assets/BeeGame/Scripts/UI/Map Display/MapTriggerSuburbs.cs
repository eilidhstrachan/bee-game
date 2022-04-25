using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapTriggerSuburbs : MonoBehaviour
{
    public static event Action OnSuburbsEnter;

    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnSuburbsEnter?.Invoke();
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
