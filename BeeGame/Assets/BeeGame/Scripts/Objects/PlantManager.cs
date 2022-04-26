using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{
    public List<GameObject> plants;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < plants.Count; i++)
        {
            plants[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PointsManager.playerPoints >= 2)
        {
            for (int i = 0; i < plants.Count; i++)
            {
                plants[i].SetActive(true);
            }
        }
    }
}
