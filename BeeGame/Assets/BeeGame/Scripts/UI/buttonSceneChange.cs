using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/*
 * Loads a new scene when a button is pressed
 */
public class ButtonSceneChange : MonoBehaviour
{
    public string scene; // the name of the scene to change to

    public void onButtonPress()
    {
        SceneManager.LoadScene(scene);
        SaveDataManager.instance.SaveGame();
    }

}
