using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonOpen : MonoBehaviour
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
        if (userInterfaceItem.activeInHierarchy == false)
        {
            userInterfaceItem.SetActive(true);
        }
    }
}
