using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        options.SetActive(true);
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

    public void CloseOptions()
    {
        if (options.activeInHierarchy == true)
        {
            options.SetActive(false);
        }
    }

    public void CloseCredits()
    {
        if (credits.activeInHierarchy == true)
        {
            credits.SetActive(false);
        }
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

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
