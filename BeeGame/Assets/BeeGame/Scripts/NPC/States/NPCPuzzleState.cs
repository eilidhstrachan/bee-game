using UnityEngine;

public class NPCPuzzleState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the puzzle state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;

                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().puzzleDialogue);
                //if (DialogueManager.GetInstance().GetComponent<DialogueValues>().choice.Equals("yes"))
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
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
        }
    }

}
