using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public GameObject form;

    // Start is called before the first frame update
    void Start()
    {
        form.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        form.SetActive(true);
    }

    public void CloseForm()
    {
        if (form.activeInHierarchy == true)
        {
            form.SetActive(false);
        }
    }

    public void NewGame()
    {
        SaveDataManager.instance.NewGame();
        SceneManager.LoadScene("Village");
    }

    public void LoadGame()
    {
        SaveDataManager.instance.LoadGame();
        SceneManager.LoadScene("Village");
    }


    public void OpenOptions()
    {

    }

    public void CloseOptions()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }



}
