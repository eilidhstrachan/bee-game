using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class lets the player's position be saved to the gamedata file, so that 
 * when the game is exited or a new scene is loaded, the player's position will
 * be remembered.
 */
public class PositionManager : MonoBehaviour, IDataManagement
{

    public void LoadData(GameData data)
    {
        Debug.Log("loading player position");
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        Debug.Log("saving player position " + this.transform.position);
        data.playerPosition = this.transform.position;
    }
}
