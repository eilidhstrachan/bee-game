using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * buttonClose hides a UI object when its exit button is pressed
 */
public class buttonClose : MonoBehaviour
{
    public GameObject userInterfaceItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonPress()
    {
        if (userInterfaceItem.activeInHierarchy == true)
        {
            userInterfaceItem.SetActive(false);
        }
    }
}
