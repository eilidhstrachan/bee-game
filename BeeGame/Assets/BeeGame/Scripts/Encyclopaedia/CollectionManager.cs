using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CollectionManager : MonoBehaviour
    {
        public int flowerCount = 0;
        
        public void AddFlowers()
        {
            flowerCount++;
            Debug.Log("Flowers = " + flowerCount);
        }

    }

