using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCollider : MonoBehaviour
{
    public bool playerInRange;
    public GameObject roof;

    // Start is called before the first frame update
    void Start()
    {
        roof.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            playerInRange = true;
            Debug.Log("player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }
}
