using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject mayorLetter;
    public GameObject startText;
    public GameObject mapDisplay;
    public bool isLetterRead;
    public bool isTextRead;
    public bool isMapOn;
    public int mapID;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource soundEffect;
    [SerializeField] Toggle mapToggle;
    [SerializeField] GameObject villageMap;
    [SerializeField] GameObject suburbsMap;
    [SerializeField] GameObject cityMap;



    // Start is called before the first frame update
    void Start()
    {
        music.volume = musicSlider.value;
        soundEffect.volume = soundSlider.value;

        if (mayorLetter.activeInHierarchy == true)
        {
            mayorLetter.SetActive(false);
        }

        if (startText.activeInHierarchy == true)
        {
            startText.SetActive(false);
        }

        if (optionsMenu.activeInHierarchy == true)
        {
            optionsMenu.SetActive(false);
        }

        if (isMapOn == true)
        {
            mapToggle.isOn = true;
            mapDisplay.SetActive(true);
        }
        else
        {
            mapToggle.isOn = false;
            mapDisplay.SetActive(false);
        }

        if (mapID == 1)
        {
            DisplayVillageMap();
        }
        else if (mapID == 2)
        {
            DisplaySuburbsMap();
        }
        else if (mapID == 3)
        {
            DisplayCityMap();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (mayorLetter.activeInHierarchy == false && isTextRead == false && isLetterRead == false)
        {
            mayorLetter.SetActive(true);
        }
        else if (startText.activeInHierarchy == false && isTextRead == true && isLetterRead == false)
        {
            startText.SetActive(true);
        }

    }

    public void DisplayVillageMap()
    {
        Debug.Log("ChangeMapImage() is being called");
        villageMap.SetActive(true);
        cityMap.SetActive(false);
        suburbsMap.SetActive(false);
        mapID = 1;
    }

    public void DisplaySuburbsMap()
    {
        Debug.Log("ChangeMapImage() is being called");
        villageMap.SetActive(false);
        cityMap.SetActive(false);
        suburbsMap.SetActive(true);
        mapID = 2;
    }

    public void DisplayCityMap()
    {
        Debug.Log("ChangeMapImage() is being called");
        villageMap.SetActive(false);
        cityMap.SetActive(true);
        suburbsMap.SetActive(false);
        mapID = 3;
    }

    private void OnEnable()
    {
        MapTriggerSuburbs.OnSuburbsEnter += DisplaySuburbsMap;
        MapTriggerVillage.OnVillageEnter += DisplayVillageMap;
        MapTriggerCity.OnCityEnter += DisplayCityMap;
    }

    private void OnDisable()
    {
        MapTriggerSuburbs.OnSuburbsEnter -= DisplaySuburbsMap;
        MapTriggerVillage.OnVillageEnter -= DisplayVillageMap;
        MapTriggerCity.OnCityEnter -= DisplayCityMap;
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

    public void ChangeSoundVolume()
    {
        soundEffect.volume = soundSlider.value;
    }

    public void DisplayMapUI()
    {
        if (mapToggle.isOn == true)
        {
            mapDisplay.SetActive(true);
            isMapOn = true;
        }
        else
        {
            mapDisplay.SetActive(false);
            isMapOn = false;
        }
    }


    public void OnStartTextExit()
    {
        startText.SetActive(false);
        isLetterRead = true;
    }

    public void OnLetterExit()
    {
        mayorLetter.SetActive(false);
        isTextRead = true;
        //isLetterRead = true;
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
        isMapOn = data.mapOn;
        mapID = data.mapDisplay;
    }

    public void SaveData(GameData data)
    {
        data.letterRead = isLetterRead;
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
        data.mapOn = isMapOn;
        data.mapDisplay = mapID;
    }
}
