using UnityEngine;

public class NPCDialogueState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName +" entered the dialogue state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        //Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " dialogue state");
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        if (npc.GetComponent<NPCStateManager>().introsHeard == false)
        {
            npc.ChangeState(npc.IntroState);
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().hasPuzzle == true)
        {
            npc.ChangeState(npc.PuzzleState);
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints < 2 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part1State);
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints >= 2 && npc.GetComponent<NPCStateManager>().npcPoints < 4 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part2State);
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints >= 4 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part3State);
        }
    }
}
