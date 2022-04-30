using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * buttonOpen sets a UI item to be active when the button to open it is pressed
 */
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
