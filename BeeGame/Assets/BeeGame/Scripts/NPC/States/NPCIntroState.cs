using UnityEngine;

/*
 * NPCs will always enter the intro state the first time the player talks to them
 */
public class NPCIntroState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log("I'm now in entering the intro state! - "+ npc.GetComponent<NPCStateManager>().NPCName);
       
    }


    public override void UpdateState(NPCStateManager npc)
    {
        // if the player is out of range or they have now read the intro dialogue, return to the idle state
        if (npc.GetComponent<NPCStateManager>().playerInRange == false || npc.introsHeard == true)
        {
            npc.ChangeState(npc.IdleState);
        }

        // if dialogue isn't currently playing, show the keyboard prompt so the player knows they can interact
        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);

            // if player presses F, initiate intro dialogue
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;
                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().inkIntro);
                npc.GetComponent<NPCStateManager>().introsHeard = true;
            }
            else
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = "";
            }
        }
        else
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
        }
    }
}
