using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonOpen : MonoBehaviour
{
    public GameObject userInterfaceItem; 


    public void onButtonPress()
    {
        if (userInterfaceItem.activeInHierarchy == false)
        {
            userInterfaceItem.SetActive(true);
        }
    }
}
