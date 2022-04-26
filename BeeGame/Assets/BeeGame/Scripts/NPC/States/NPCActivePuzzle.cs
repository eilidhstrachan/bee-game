using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCActivePuzzle : NPCBaseState, IDataManagement
{
    private int puzzleID;
    private bool finish;

    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log("Entered active puzzle state");
        puzzleID = npc.GetComponent<NPCStateManager>().npcID;
        SaveDataManager.instance.SaveGame();
        SceneManager.LoadScene(npc.GetComponent<NPCStateManager>().scene);
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
        Debug.Log("Finish = "+ finish);

    }

}
