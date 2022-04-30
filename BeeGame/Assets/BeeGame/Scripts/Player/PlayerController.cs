using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controller class for the Player, has references to the application, player model and view.
 * Contains the logic for making the player move.
 */
public class PlayerController : MonoBehaviour
{
    public VillageApplication app { get { return GameObject.FindObjectOfType<VillageApplication>(); } }
    public PlayerModel model { get; private set; }
    public PlayerView view { get; private set; }

    public void OnUpdate()
    {
        app.model.player.movement.x = Input.GetAxisRaw("Horizontal"); // sets the player model's x axis movement to be the Horizontal input from the player
        app.model.player.movement.y = Input.GetAxisRaw("Vertical"); // sets the player model's y axis movement to be the Vertical input from the player

        // processes the player movement animations for all directions
        app.model.player.animator.SetFloat("Horizontal", app.model.player.movement.x);
        app.model.player.animator.SetFloat("Vertical", app.model.player.movement.y);
        app.model.player.animator.SetFloat("Speed", app.model.player.movement.sqrMagnitude);
    }

    public void OnFixedUpdate()
    {
        // if there is dialogue playing, return so the player can't move until it is completed. Animator still shows the player trying to move so they know the game hasn't frozen.
        if (DialogueManager.GetInstance().dialogueIsRunning)
        {
            return;
        }
        else if (app.model.player.book.activeInHierarchy == true)
        {
            return; // returns if scrapbook UI is open so the player can't move about
        }

        // updates the player model's rigidbody position using the movement and move speed value, multiplied by fixed delta time
        app.model.player.rb.MovePosition(app.model.player.rb.position + app.model.player.movement * app.model.player.moveSpeed * Time.fixedDeltaTime);

    }


}
