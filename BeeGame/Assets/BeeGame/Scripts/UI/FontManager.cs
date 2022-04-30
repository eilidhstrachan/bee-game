using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * FontManager allows the player to change between the pixel font and the dyslexia friendly font
 */
public class FontManager : MonoBehaviour, IDataManagement
{
    // variables to show in inspector
    public bool isPixelFontOff;
    public Font readableFont;
    public Font pixelFont;
    public Toggle fontToggle;
    public TMP_FontAsset tmpReadable;
    public TMP_FontAsset tmpPixel;
    public List<TextMeshProUGUI> tmpObjects;

    // initialises the font types
    public void Start()
    {
        if (isPixelFontOff == true)
        {
            fontToggle.isOn = true;
        }
        else if (isPixelFontOff == false)
        {
            fontToggle.isOn = false;
        }
    }

    // when the toggle value changes
    public void OnToggleChanged()
    {
        // if toggle is on, set font to the readable font
        if (fontToggle.isOn == true)
        {
            ChangeToReadableFont();
            isPixelFontOff = true;
        }
        else if (fontToggle.isOn == false)
        {
            // if toggle is off, change to the pixel style font
            ChangeToPixelFont();
            isPixelFontOff = false;
        }
    }

    // changes all text and tmp objects font to be the readable font
    public void ChangeToReadableFont()
    {
        var textComponents = Component.FindObjectsOfType<Text>(true);
        foreach (var component in textComponents)
        {
            component.font = readableFont;
        }

        for (int i = 0; i < tmpObjects.Count; i++)
        {
            tmpObjects[i].font = tmpReadable;
        }


        // the commented out code was an attempt at getting all the tmp text objects through the code rather than the inspector, but it didn't work
        /*
        tmpObjects = GameObject.FindGameObjectsWithTag("TextMesh");
        foreach (GameObject tmp in tmpObjects)
        {
            TextMeshPro b = tmp.GetComponent<TextMeshPro>();
            b.font = tmpReadable;

        }*/

        /*
        var tmpComponents = Component.FindObjectOfType<TextMeshProUGUI>(true);
        foreach (var component in tmpComponents)
        {
            component.font = readableFont;
        }*/
    }

    // changes all text and tmp objects font to be the pixel font
    public void ChangeToPixelFont()
    {
        var textComponents = Component.FindObjectsOfType<Text>(true);
        foreach (var component in textComponents)
        {
            component.font = pixelFont;
        }

        for (int i = 0; i < tmpObjects.Count; i++)
        {
            tmpObjects[i].font = tmpPixel;
        }
    }

    // loads font type from gamedata file
    public void LoadData(GameData data)
    {
        isPixelFontOff = data.pixelFontOff;
    }

    // saves selected font type to gamedata file
    public void SaveData(GameData data)
    {
        data.pixelFontOff = isPixelFontOff;
    }
}
