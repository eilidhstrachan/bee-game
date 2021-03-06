using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GameData holds all data related to the current game
 */
[System.Serializable]
public class GameData
{
    public float musicVolume;
    public float soundVolume;
    public bool pixelFontOff;
    public bool mapOn;
    public bool letterRead;
    public bool demoRead;
    public int puzzlePoints;
    public int mapDisplay; // 1 for village, 2 for suburbs, 3 for city
    public Vector3 playerPosition;
    public SerializeDictionary<int, bool> flowers;
    public SerializeDictionary<int, bool> puzzles;
    public SerializeDictionary<int, bool> postPuzzle;
    public string npcPuzzle;
    public SerializeDictionary<int, bool> npcIntro;


    // constructor for initialising game data variables when a new game is started without loading
    // a previous save file
    public GameData()
    {
        mapOn = true;
        pixelFontOff = false;
        musicVolume = 1; // sets volume to maximum value
        soundVolume = 1; // sets volume to maximum value
        letterRead = false; // letterread is false so the letter can be displaed at the start of the game
        demoRead = false;
        this.puzzlePoints = 0;
        this.mapDisplay = 1;
        this.playerPosition = new Vector3(2.925f, 0.06f, 0); // the starting position for a new game
        flowers = new SerializeDictionary<int, bool>();
        npcPuzzle = "";
        puzzles = new SerializeDictionary<int, bool>();
        postPuzzle = new SerializeDictionary<int, bool>();
        npcIntro = new SerializeDictionary<int, bool>();
    }
}
