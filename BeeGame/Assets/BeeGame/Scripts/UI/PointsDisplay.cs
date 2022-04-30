using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*
 * this script deals with displaying the player's puzzle point count in the UI, and also saving
 * that value to the game data file, and loading in previous values to the UI
 */
public class PointsDisplay : MonoBehaviour, IDataManagement
{
    public TextMeshProUGUI pointsDisplay;
    private int points = 0;
    public GameObject manager;

    //public static event Action OnPointsIncreased; used when I was attempting to use an observer to get the points value

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(pointsDisplay.text) != points)
        {
            Debug.Log("Adding points to display");
            pointsDisplay.text = points.ToString();
            //OnPointsIncreased?.Invoke();
           
        }
     }

    public void LoadData(GameData data)
    {
        this.points = data.puzzlePoints;
    }

    public void SaveData(GameData data)
    {
        data.puzzlePoints = this.points;
    }

    public int GetPoints()
    {
        return points;
    }

}


