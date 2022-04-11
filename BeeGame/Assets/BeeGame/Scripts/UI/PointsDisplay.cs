using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour, IDataManagement
{
    public TextMeshProUGUI pointsDisplay;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsDisplay.text = points.ToString();
    }

    public void LoadData(GameData data)
    {
        this.points = data.puzzlePoints;
    }

    public void SaveData(ref GameData data)
    {
        data.puzzlePoints = this.points;
    }
}
