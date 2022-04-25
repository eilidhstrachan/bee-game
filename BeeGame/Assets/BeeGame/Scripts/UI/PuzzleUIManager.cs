using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject hint;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource soundEffect;

    // Start is called before the first frame update
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
        optionsMenu.SetActive(true);
    }

    public void DisplayHint()
    {
        hint.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

    public void ChangeSoundVolume()
    {
        soundEffect.volume = soundSlider.value;
    }


    public void LoadData(GameData data)
    {
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
    }

    public void SaveData(GameData data)
    {
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
    }
}
