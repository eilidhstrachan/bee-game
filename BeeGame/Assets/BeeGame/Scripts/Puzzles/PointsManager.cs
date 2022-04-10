using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static int playerPoints;
    public TextMeshProUGUI pointsDisplay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Points" + playerPoints);
        pointsDisplay.text = playerPoints.ToString();
    }
}
