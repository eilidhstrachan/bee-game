using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject mayorLetter;
    public bool isLetterRead;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource soundEffect;


    // Start is called before the first frame update
    void Start()
    {
        music.volume = musicSlider.value;
        soundEffect.volume = soundSlider.value;

        if (mayorLetter.activeInHierarchy == true)
        {
            mayorLetter.SetActive(false);
        }

        if (optionsMenu.activeInHierarchy == true)
        {
            optionsMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mayorLetter.activeInHierarchy == false && isLetterRead == false)
        {
            mayorLetter.SetActive(true);
        }
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

    public void ChangeSoundVolume()
    {
        soundEffect.volume = soundSlider.value;
    }

    public void OnLetterExit()
    {
        mayorLetter.SetActive(false);
        isLetterRead = true;
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void LoadData(GameData data)
    {
        isLetterRead = data.letterRead;
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
    }

    public void SaveData(GameData data)
    {
        data.letterRead = isLetterRead;
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
    }
}
