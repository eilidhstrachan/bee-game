using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Handles all the UI options while in the overworld scene
 */
public class UIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject scrapbook;
    public GameObject mayorLetter;
    public GameObject startText;
    public GameObject mapDisplay;
    public GameObject demoPopup;
    public bool isDemoRead;
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

        demoPopup.SetActive(false);

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

        // shows/hides the map 
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

        // chooses which map image to display
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
        // shows the mayor letter if it hasn't already been read
        if (mayorLetter.activeInHierarchy == false && isTextRead == false && isLetterRead == false)
        {
            mayorLetter.SetActive(true);
        }
        else if (startText.activeInHierarchy == false && isTextRead == true && isLetterRead == false)
        {
            startText.SetActive(true); // shows the start text if it hasn't already been read
        }

        // hides scrapbook and options menu while dialogue is being displayed
        if (DialogueManager.GetInstance().dialogueIsRunning == true)
        {
            scrapbook.SetActive(false);
            optionsMenu.SetActive(false);
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
        if (isDemoRead == false)
        {
            demoPopup.SetActive(true);
            isDemoRead = true;
        }
    }

    public void HideDemoPopup()
    {
        demoPopup.SetActive(false);
    }

    // observer pattern, calls related map display methods to change map image
    private void OnEnable()
    {
        MapTriggerSuburbs.OnSuburbsEnter += DisplaySuburbsMap;
        MapTriggerVillage.OnVillageEnter += DisplayVillageMap;
        MapTriggerCity.OnCityEnter += DisplayCityMap;
    }

    // disables observers
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

    // displays the map UI if the toggle is set to on
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

    // when start text is closed, set it to be read
    public void OnStartTextExit()
    {
        startText.SetActive(false);
        isLetterRead = true;
    }

    // when the letter is closed, set it to be read
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

    // load all related UI data from gamedata
    public void LoadData(GameData data)
    {
        isLetterRead = data.letterRead;
        isDemoRead = data.demoRead;
        musicSlider.value = data.musicVolume;
        soundSlider.value = data.soundVolume;
        isMapOn = data.mapOn;
        mapID = data.mapDisplay;
    }

    // save all related UI data to gamedata
    public void SaveData(GameData data)
    {
        data.letterRead = isLetterRead;
        data.demoRead = isDemoRead;
        data.musicVolume = musicSlider.value;
        data.soundVolume = soundSlider.value;
        data.mapOn = isMapOn;
        data.mapDisplay = mapID;
    }
}
