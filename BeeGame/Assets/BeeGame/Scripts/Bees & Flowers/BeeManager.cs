using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    public List<GameObject> bees;
    public List<GameObject> flowerItems;
    public List<GameObject> flowerObjects;

    public void Awake()
    {
        for (int i = 0; i < bees.Count; i++)
        {
            bees[i].SetActive(false);
        }

        for (int i = 0; i < flowerObjects.Count; i++)
        {
            flowerObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < flowerItems.Count; i++)
        { 
            if (flowerItems[i].activeInHierarchy == false)
            {
                bees[i].SetActive(true);
                flowerObjects[i].SetActive(true);
            }
        }
    }
}
