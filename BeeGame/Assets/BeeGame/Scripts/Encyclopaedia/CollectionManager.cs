using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  CollectionManager was intended to handle the flowers being added to the scrapbook/encyclopaedia
 *  I don't want to delete it as I think AddFlowers() might actually be used somewhere.
 */
    public class CollectionManager : MonoBehaviour
    {
        public int flowerCount = 0;
        
        public void AddFlowers()
        {
            flowerCount++;
            Debug.Log("Flowers = " + flowerCount);
        }

    }

