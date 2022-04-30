using UnityEngine;

/*
 * This state contains all the logic for deciding which state the NPC should be in to display the most
 * relevant dialogue for the point in the story the player is at.
 */
public class NPCDialogueState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log(npc.GetComponent<NPCStateManager>().NPCName +" entered the dialogue state");
    }

    public override void UpdateState(NPCStateManager npc)
    {
        //Debug.Log(npc.GetComponent<NPCStateManager>().NPCName + " dialogue state"); for testing

        // if the player is out of range, return to the idle state
        if (npc.GetComponent<NPCStateManager>().playerInRange == false)
        {
            npc.ChangeState(npc.IdleState);
        }

        if (npc.GetComponent<NPCStateManager>().introsHeard == false)
        {
            npc.ChangeState(npc.IntroState); // enter intro state if player hasn't read the NPC's intro yet
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().hasPuzzle == true)
        {
            npc.ChangeState(npc.PuzzleState); // if intro has been read & the NPC has a puzzle, enter the puzzle state
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().postPuzzleHeard == false && npc.GetComponent<NPCStateManager>().puzzleCompleted == true)
        {
            npc.ChangeState(npc.PostPuzzle); // if the NPC had a puzzle and it has been completed, enter post puzzle state
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints < 2 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part1State); // if NPC doesn't have a puzzle/it is completed, and the player has less than 2 puzzle points, enter the Part 1 state
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints >= 2 && npc.GetComponent<NPCStateManager>().npcPoints < 4 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part2State); // if NPC doesn't have a puzzle/it is completed, and the player has 2 or 3 puzzle points, enter the Part 2 state
        }
        else if (npc.GetComponent<NPCStateManager>().introsHeard == true && npc.GetComponent<NPCStateManager>().npcPoints >= 4 && npc.GetComponent<NPCStateManager>().hasPuzzle == false)
        {
            npc.ChangeState(npc.Part3State); // if NPC doesn't have a puzzle/it is completed, and the player has 4 or more puzzle points, enter the Part 3 state
        }
    }
}
