using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
