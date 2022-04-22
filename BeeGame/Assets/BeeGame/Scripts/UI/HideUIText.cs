using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideUIText : MonoBehaviour
{
    public GameObject objectToShow;
    public TMP_Text textToHide;
    public TMP_Text answerToHide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objectToShow.activeInHierarchy == true)
        {
            textToHide.text = "+";
            answerToHide.text = "";
        }
    }
}
