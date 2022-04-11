using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int puzzlePoints;
    public Vector3 playerPosition;

    // constructor for initialising game data variables when a new game is started without loading
    // a previous save file
    public GameData()
    {
        this.puzzlePoints = 0;
        this.playerPosition = Vector3.zero;
    }
}
