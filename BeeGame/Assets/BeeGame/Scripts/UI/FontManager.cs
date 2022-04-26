using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FontManager : MonoBehaviour, IDataManagement
{
    public bool isPixelFontOff;
    public Font readableFont;
    public Font pixelFont;
    public Toggle fontToggle;
    public TMP_FontAsset tmpReadable;
    public TMP_FontAsset tmpPixel;
    public List<TextMeshProUGUI> tmpObjects;

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

    public void OnToggleChanged()
    {
        if (fontToggle.isOn == true)
        {
            ChangeToReadableFont();
            isPixelFontOff = true;
        }
        else if (fontToggle.isOn == false)
        {
            ChangeToPixelFont();
            isPixelFontOff = false;
        }
    }

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

    public void LoadData(GameData data)
    {
        isPixelFontOff = data.pixelFontOff;
    }

    public void SaveData(GameData data)
    {
        data.pixelFontOff = isPixelFontOff;
    }
}
