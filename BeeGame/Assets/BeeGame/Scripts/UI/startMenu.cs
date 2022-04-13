using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public GameObject startForm;
    public GameObject instructions;
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        startForm.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(false);
    }

    public void StartGame()
    {
        startForm.SetActive(true);
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

    public void Instructions()
    {
        instructions.SetActive(true);
    }

    public void ShowOptions()
    {

    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseStartForm()
    {
        if (startForm.activeInHierarchy == true)
        {
            startForm.SetActive(false);
        }
    }
    public void CloseInstructions()
    {
        if (instructions.activeInHierarchy == true)
        {
            instructions.SetActive(false);
        }
    }

    public void CloseCredits()
    {
        if (credits.activeInHierarchy == true)
        {
            credits.SetActive(false);
        }
    }

}
