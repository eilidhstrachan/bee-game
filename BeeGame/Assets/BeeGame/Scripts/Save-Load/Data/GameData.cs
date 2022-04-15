using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool letterRead;
    public int puzzlePoints;
    public Vector3 playerPosition;
    public SerializeDictionary<int, bool> flowers;
    public SerializeDictionary<int, bool> puzzles;

    // constructor for initialising game data variables when a new game is started without loading
    // a previous save file
    public GameData()
    {
        letterRead = false;
        this.puzzlePoints = 0;
        this.playerPosition = Vector3.zero;
        flowers = new SerializeDictionary<int, bool>();
        puzzles = new SerializeDictionary<int, bool>();
    }
}