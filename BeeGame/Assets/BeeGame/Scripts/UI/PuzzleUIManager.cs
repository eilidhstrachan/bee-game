using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script to manage all the different Puzzle UI options
 */
public class PuzzleUIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject hint;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource soundEffect;

    // Start is called before the first frame update, initialises all values and hides the options UI menu
    void Start()
    {
        optionsMenu.SetActive(false);
        hint.SetActive(false);

        music.volume = musicSlider.value;
        soundEffect.volume = soundSlider.value;

        if (optionsMenu.activeInHierarchy == true)
        {
            optionsMenu.SetActive(false);
        }
    }

    public void DisplayOptions()
    {
        optionsMenu.SetActive(true); // shows the options menu
    }

    public void DisplayHint()
    {
        hint.SetActive(true); // shows the hint
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false); // closes the options menu
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value; // sets the music volume to the value of the slider
    }

    public void ChangeSoundVolume()
    {
        soundEffect.volume = soundSlider.value; // sets the sound effect volume to the value of the slider
    }

    // loads previous data from gamedata file
    public void LoadData(GameData data)
    {
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
    }

    // saves current data to gamedata file
    public void SaveData(GameData data)
    {
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
    }
}
