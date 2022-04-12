using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    public List<GameObject> bees;
    public List<GameObject> flowers;

    public void Awake()
    {
        for (int i = 0; i < bees.Count; i++)
        {
            bees[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < flowers.Count; i++)
        { 
            if (flowers[i].activeInHierarchy == false)
            {
                bees[i].SetActive(true);
            }
        }
    }
}
