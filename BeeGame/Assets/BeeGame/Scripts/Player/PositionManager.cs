using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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