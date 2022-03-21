using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonSceneChange : MonoBehaviour
{
    public string scene; // the name of the scene to change to

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
        SceneManager.LoadScene("StartMenu");
    }
}
