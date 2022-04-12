using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    private int flowerCount = 0;

    public void AddFlowers()
    {
        flowerCount++;
        Debug.Log("Flowers = " + flowerCount);
    }

}
