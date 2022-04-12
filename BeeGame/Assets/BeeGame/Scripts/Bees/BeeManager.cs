using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    public List<GameObject> bees;
    public List<GameObject> flowers;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bees.Count; i++)
        {
            bees[i].SetActive(false);
        }
    }

    public void BeeAppear()
    {
        for (int i = 0; i < flowers.Count; i++)
        {
            if (bees[i].activeInHierarchy == false && flowers[i].activeInHierarchy == false)
            {
                bees[i].SetActive(true);
            }
        }
    }
}
