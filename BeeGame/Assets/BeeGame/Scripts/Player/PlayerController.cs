using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VillageApplication app { get { return GameObject.FindObjectOfType<VillageApplication>(); } }
    public PlayerModel model { get; private set; }
    public PlayerView view { get; private set; }

    public void OnUpdate()
    {
        app.model.player.movement.x = Input.GetAxisRaw("Horizontal");
        app.model.player.movement.y = Input.GetAxisRaw("Vertical");

        app.model.player.animator.SetFloat("Horizontal", app.model.player.movement.x);
        app.model.player.animator.SetFloat("Vertical", app.model.player.movement.y);
        app.model.player.animator.SetFloat("Speed", app.model.player.movement.sqrMagnitude);
    }

    public void OnFixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsRunning)
        {
            return;
        }

        app.model.player.rb.MovePosition(app.model.player.rb.position + app.model.player.movement * app.model.player.moveSpeed * Time.fixedDeltaTime);

    }




    //public void AddPuzzlePoints()
    //{
    //app.model.player.puzzlePoints++;
    //Debug.Log("Puzzle points added! = " + app.model.player.puzzlePoints);
    //}


}
