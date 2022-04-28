using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * RoofCollider makes a roof GameObject slightly transparent when a player is in range of 
 * the roof's box collider 2D to give the illusion of the player walking into the house and 
 * being underneath the roof, while still being able to see where they are going.
 */
public class RoofCollider : MonoBehaviour
{
    public bool playerInRange;
    public GameObject roof; // the roof GameObject to make transparent

    // Start is called before the first frame update
    void Start()
    {
        // makes sure the roof GameObject is active
        roof.SetActive(true);
    }

    // when the the player collider enters the roof collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // sets the roof sprite to appear slightly transparent
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            playerInRange = true;
            Debug.Log("player in range");
        }
    }

    // when the player collider exits the roof collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // sets the roof sprite to appear completely solid
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            playerInRange = false;
            Debug.Log("player out of range");
        }
    }
}
