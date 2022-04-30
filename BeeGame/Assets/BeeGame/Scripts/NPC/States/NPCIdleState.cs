using UnityEngine;

/*
 * NPCs will always be in the idle state when the player is out of range
 */
public class NPCIdleState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the idle state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        //Debug.Log("I'm idling!!! - "+ npc.GetComponent<NPCStateManager>().NPCName); for testing
        //Debug.Log(npc.GetComponent<NPCStateManager>().playerInRange);
        if (npc.GetComponent<NPCStateManager>().playerInRange == true)
        {
            npc.ChangeState(npc.DialogueState); // if the player is in range, enter the dialogue state
        }
        else
        {
            // hide the prompt and puzzle prompt game objects
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
            npc.GetComponent<NPCStateManager>().puzzlePrompt.SetActive(false);
        }
    }
}
