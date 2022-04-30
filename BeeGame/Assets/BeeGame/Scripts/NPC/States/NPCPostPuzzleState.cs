using UnityEngine;

/*
 * This state is for displaying dialogue related to the puzzle the player has just completed.
 * NPCs will only move onto the next state (other than idle/dialogue) once this dialogue has been read, like the intro state dialogue.
 */
public class NPCPostPuzzleState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the post puzzle state");
        npc.GetComponent<NPCStateManager>().puzzlePrompt.SetActive(false); // hides the puzzle prompt (!) icon
    }

    public override void UpdateState(NPCStateManager npc)
    {
        // if player goes out of range, return to idle state
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        // if dialogue isn't currently playing, show the keyboard prompt
        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);

            // if player presses F, display the post puzzle dialogue ink file
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;

                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().postPuzzle);
                npc.GetComponent<NPCStateManager>().postPuzzleHeard = true;
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
