using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " has entered the idle state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        //Debug.Log("I'm idling!!! - "+ npc.GetComponent<NPCStateManager>().NPCName);
        //Debug.Log(npc.GetComponent<NPCStateManager>().playerInRange);
        if (npc.GetComponent<NPCStateManager>().playerInRange == true)
        {
            npc.ChangeState(npc.DialogueState);
        }
        else
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
        }
    }
}
