using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This state is for displaying dialogue relating to starting a puzzle.
 * Only NPCs who have puzzles will enter this state. NPCs won't leave this state (other than to go to idle/dialogue)
 * until the puzzle has been completed. This is so the player won't accidentally miss it and get stuck without
 * being able to progress.
 */
public class NPCPuzzleState : NPCBaseState
{ 
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the puzzle state");
    }

    // if player goes out of range, return to idle state
    public override void UpdateState(NPCStateManager npc)
    {
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        // if the player chose that they wanted to start the puzzle, enter the active puzzle state once dialogue has finished so the puzzle scene can be loaded
        if (DialogueValues.choice.Equals("yes") && !DialogueManager.GetInstance().dialogueIsRunning)
        {
            Debug.Log("NPCPuzzleState says that choice is equal to yes");
            DialogueValues.choice = "no";
            npc.ChangeState(npc.ActivePuzzle);

        }

        // if dialogue isn't currently playing, show the keyboard prompt
        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);
            npc.GetComponent<NPCStateManager>().puzzlePrompt.SetActive(true); // show the (!) icon so the player knows the NPC has a puzzle to complete

            // if player presses F, display the puzzle dialogue ink file
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;

                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                npc.GetComponent<NPCStateManager>().puzzlePrompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().puzzleDialogue);

                //if (DialogueManager.GetInstance().GetComponent<DialogueValues>().choice.Equals("yes")) used for testing
                //{
                //Debug.Log("Choice was yes!" + DialogueManager.GetInstance().GetComponent<DialogueValues>().choice);
                //}
            }
            else
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = "";
            }
        }
        else
        {
            npc.GetComponent<NPCStateManager>().puzzlePrompt.SetActive(false);
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
        }
    }

}
