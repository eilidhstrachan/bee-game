using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float musicVolume;
    public float soundVolume;
    public bool mapOn;
    public bool letterRead;
    public bool demoRead;
    public int puzzlePoints;
    public int mapDisplay; // 1 for village, 2 for suburbs, 3 for city
    public Vector3 playerPosition;
    public SerializeDictionary<int, bool> flowers;
    public SerializeDictionary<int, bool> puzzles;
    public string npcPuzzle;
    public SerializeDictionary<int, bool> npcIntro;


    // constructor for initialising game data variables when a new game is started without loading
    // a previous save file
    public GameData()
    {
        mapOn = true;
        musicVolume = 1;
        soundVolume = 1;
        letterRead = false;
        demoRead = false;
        this.puzzlePoints = 0;
        this.mapDisplay = 1;
        this.playerPosition = new Vector3(2.925f, 0.06f, 0);
        flowers = new SerializeDictionary<int, bool>();
        npcPuzzle = "";
        puzzles = new SerializeDictionary<int, bool>();
        npcIntro = new SerializeDictionary<int, bool>();
    }
}
