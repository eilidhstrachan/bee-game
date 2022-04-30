using UnityEngine;

/*
 * This state is for displaying the relevant part2 dialogue.
 */
public class NPCPart2State : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the part 2 state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        //Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " part 2 state"); for testing

        // if player goes out of range, return to idle state
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        // if dialogue isn't currently playing, show the keyboard prompt
        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);

            // if player presses F, display the part2 dialogue ink file
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;

                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().inkPart2);
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
