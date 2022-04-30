using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interface for implementing the save/load methods
public interface IDataManagement 
{
    void LoadData(GameData data);

    void SaveData(GameData data);
}
