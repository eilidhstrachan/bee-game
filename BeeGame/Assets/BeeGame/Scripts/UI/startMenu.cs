using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This script handles all the different buttons and options in the 
 * StartMenu scene.
 */
public class startMenu : MonoBehaviour, IDataManagement
{
    public GameObject startForm;
    public GameObject instructions;
    public GameObject options;
    public GameObject credits;
    public bool isMapOn;

    [SerializeField] Toggle mapToggle;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        startForm.SetActive(false);
        instructions.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);

        if (isMapOn == false)
        {
            mapToggle.isOn = false;
        }
        else
        {
            mapToggle.isOn = true;
        }
    }

    void Update()
    {
        if (mapToggle.isOn == true)
        {
            isMapOn = true;
        }
        else
        {
            isMapOn = false;
        }
    }

    public void StartGame()
    {
        startForm.SetActive(true); // displays the start form
    }

    public void NewGame()
    {
        SaveDataManager.instance.NewGame(); // starts a new game
        SceneManager.LoadScene("Village"); // loads the "Village" overworld scene
    }

    public void LoadGame()
    {
        SaveDataManager.instance.LoadGame(); // loads previous game data
        SceneManager.LoadScene("Village"); // loads the "Village" overworld scene
    }

    public void Instructions()
    {
        instructions.SetActive(true); // shows the instructions
    }

    public void ShowOptions()
    {
        options.SetActive(true); // shows the options menu
    }

    public void Credits()
    {
        credits.SetActive(true); // shows the credits
    }

    public void Quit()
    {
        Application.Quit(); // quits the application
    }

    // closes the start form
    public void CloseStartForm()
    {
        if (startForm.activeInHierarchy == true)
        {
            startForm.SetActive(false);
        }
    }

    // closes the instructions
    public void CloseInstructions()
    {
        if (instructions.activeInHierarchy == true)
        {
            instructions.SetActive(false);
        }
    }

    // closes the options menu
    public void CloseOptions()
    {
        if (options.activeInHierarchy == true)
        {
            options.SetActive(false);
        }
    }

    // closes the credits
    public void CloseCredits()
    {
        if (credits.activeInHierarchy == true)
        {
            credits.SetActive(false);
        }
    }

    // sets the music volume to the value of the slider
    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

    // gets the current value of the toggle
    public void GetToggleValue()
    {
        if (mapToggle.isOn == true)
        {
            isMapOn = true;
        }
        else
        {
            isMapOn = false;
        }
    }

    public void LoadData(GameData data)
    {
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
        isMapOn = data.mapOn;
    }

    public void SaveData(GameData data)
    {
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
        data.mapOn = isMapOn;
    }
}
