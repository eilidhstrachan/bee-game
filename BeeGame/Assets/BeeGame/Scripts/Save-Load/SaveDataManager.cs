using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

// made with the help of How to make a Save & Load System in Unity | 2022 https://www.youtube.com/watch?v=aUi9aijvpgs by Trevor Mock
// script to manage the data persistence between scenes and game save/loads.
// uses a singleton so that only one instance of this class can exist per game.
public class SaveDataManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    [SerializeField] private string fileName;

    private FileHandler fileHandler;
    private GameData gameData;
    private List<IDataManagement> dataManagementObjects;

    public static SaveDataManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Save Data Manager exists in this scene");
            Destroy(this.gameObject);
            Debug.Log("Destroyed the additional instance of Save Data Manager");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        this.fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        this.dataManagementObjects = FindAllDataManagementObjects();
        LoadGame();
    }

    private List<IDataManagement> FindAllDataManagementObjects()
    {
        IEnumerable<IDataManagement> dataManagementObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataManagement>();

        return new List<IDataManagement>(dataManagementObjects);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataManagementObjects = FindAllDataManagementObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    // creates a new instance of the GameData class
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IDataManagement dataObject in dataManagementObjects)
        {
            dataObject.SaveData(gameData);
        }

        Debug.Log("Current saved puzzle points = " + gameData.puzzlePoints);
        Debug.Log("Current saved position = " + gameData.playerPosition);

        fileHandler.Save(gameData);
    }

    public void LoadGame()
    {
        this.gameData = fileHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No save data was found");
            NewGame();
        }

        foreach (IDataManagement dataObject in dataManagementObjects)
        {
            dataObject.LoadData(gameData);
        }

        Debug.Log("Amount of puzzle points loaded in = " + gameData.puzzlePoints);
        Debug.Log("Player position loaded in = " + gameData.playerPosition);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
