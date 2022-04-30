using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * script to make main camera follow the player as they move throughout the game
 */
public class followPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -5);
    }
}
