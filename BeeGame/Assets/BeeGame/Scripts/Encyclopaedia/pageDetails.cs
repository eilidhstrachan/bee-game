using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * This code isn't actually used.
 * Instead of setting the book space objects to be inactive and the flower buttons to be active when
 * a flower is picked up, I was trying to find a way to just change the sprite.
 */
public class pageDetails : MonoBehaviour
{
    public string flowerName;
    public string description;
    public Sprite flowerSprite;
    public GameObject photo;
    public TextMeshProUGUI pageName;
    public TextMeshProUGUI pageDescription;

    public void onButtonPress()
    {
        photo.GetComponent<Image>().sprite = flowerSprite;
        pageName.text = flowerName;
        pageDescription.text = description; 
    }
}
