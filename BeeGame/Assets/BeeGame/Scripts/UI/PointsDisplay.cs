using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointsDisplay : MonoBehaviour, IDataManagement
{
    public TextMeshProUGUI pointsDisplay;
    private int points = 0;
    public GameObject manager;

    //public static event Action OnPointsIncreased;


    // Start is called before the first frame update
    void Awake()
    {

    }

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


