using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script to hold the value of the player's puzzle point count so it can be accessed by other scripts
public class PointsManager : MonoBehaviour, IDataManagement
{
    public static int playerPoints;
    //public TextMeshProUGUI pointsDisplay;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        playerPoints = data.puzzlePoints;
    }

    public void SaveData(GameData data)
    {
        data.puzzlePoints = playerPoints;
    }

}
