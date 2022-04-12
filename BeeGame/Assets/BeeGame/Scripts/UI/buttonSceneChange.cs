using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    public string scene; // the name of the scene to change to

    public void onButtonPress()
    {
        SceneManager.LoadScene(scene);
        SaveDataManager.instance.SaveGame();
    }
}
