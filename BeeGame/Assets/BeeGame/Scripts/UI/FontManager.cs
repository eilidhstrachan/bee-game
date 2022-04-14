using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    public Font readableFont;
    public Font pixelFont;
    public TMP_FontAsset tmpReadable;
    private GameObject[] tmpObjects;

    public void ChangeToReadableFont()
    {
        var textComponents = Component.FindObjectsOfType<Text>(true);
        foreach (var component in textComponents)
        {
            component.font = readableFont;
        }

        tmpObjects = GameObject.FindGameObjectsWithTag("TextMesh");
        foreach (GameObject tmp in tmpObjects)
        {
            TextMeshPro b = tmp.GetComponent<TextMeshPro>();
            b.font = tmpReadable;

        }

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
    }
}
