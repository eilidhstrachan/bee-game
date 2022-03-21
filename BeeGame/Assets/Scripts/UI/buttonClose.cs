using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
