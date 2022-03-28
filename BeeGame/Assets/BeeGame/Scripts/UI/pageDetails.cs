using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pageDetails : MonoBehaviour
{
    public string flowerName;
    public string description;
    public Sprite flowerSprite;
    public GameObject photo;
    public TextMeshProUGUI pageName;
    public TextMeshProUGUI pageDescription;

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
        photo.GetComponent<Image>().sprite = flowerSprite;
        pageName.text = flowerName;
        pageDescription.text = description; 
    }
}
