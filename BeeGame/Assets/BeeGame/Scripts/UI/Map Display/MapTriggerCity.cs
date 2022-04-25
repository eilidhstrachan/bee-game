using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapTriggerCity : MonoBehaviour
{
    public static event Action OnCityEnter;

    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCityEnter?.Invoke();
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
