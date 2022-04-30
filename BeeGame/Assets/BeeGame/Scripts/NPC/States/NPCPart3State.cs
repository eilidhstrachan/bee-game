using UnityEngine;

/*
 * This state is for displaying the relevant part3 dialogue.
 */
public class NPCPart3State : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the part 3 state");
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

            // if player presses F, display the part3 dialogue ink file
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;

                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().inkPart3);
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
