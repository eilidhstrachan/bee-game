using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * I made this state for the NPC to enter once the player has selected to start a puzzle, this just made it easier to 
 * have it so that the NPC finishes their dialogue and then enters the relevant puzzle scene.
 */
public class NPCActivePuzzle : NPCBaseState, IDataManagement
{
    private int puzzleID; // the relevant puzzle's puzzleID matches the NPC's npcID
    private bool finish;

    // when an NPC enters this state, the puzzle scene is loaded
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log("Entered active puzzle state");
        puzzleID = npc.GetComponent<NPCStateManager>().npcID; // receive the NPC's ID from the StateManager class
        SaveDataManager.instance.SaveGame();
        SceneManager.LoadScene(npc.GetComponent<NPCStateManager>().scene); // loads the puzzle scene
    }

    public void LoadData(GameData data)
    {
        data.puzzles.TryGetValue(puzzleID, out finish);
    }

    public void SaveData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(NPCStateManager npc)
    {
        Debug.Log("Finish = "+ finish); // for testing

    }

}
