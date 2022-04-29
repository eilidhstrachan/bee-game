using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * class to handle displaying the plant objects in the farm
 */
public class PlantManager : MonoBehaviour
{
    // plant gameobjects to display in the inspector
    public List<GameObject> plants;

    // Start is called before the first frame update
    void Start()
    {
        // sets all the plants to be hidden
        for (int i = 0; i < plants.Count; i++)
        {
            plants[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the player has 2 or more points, shows the plants in the farm
        if (PointsManager.playerPoints >= 2)
        {
            for (int i = 0; i < plants.Count; i++)
            {
                plants[i].SetActive(true);
            }
        }
    }
}
