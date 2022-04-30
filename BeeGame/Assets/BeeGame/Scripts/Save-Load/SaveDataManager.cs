using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

/* 
 * made with the help of How to make a Save & Load System in Unity | 2022 https://www.youtube.com/watch?v=aUi9aijvpgs by Trevor Mock
 * script to manage the data persistence between scenes and game save/loads.
 * uses a singleton so that only one instance of this class can exist per game.
 */
public class SaveDataManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    [SerializeField] private string fileName; // file to be saved to
    [SerializeField] private bool encryptionEnabled; // used to set if I want the file data to be encrypted or not

    private FileHandler fileHandler;
    private GameData gameData;
    private List<IDataManagement> dataManagementObjects;

    public static SaveDataManager instance { get; private set; }

    private void Awake()
    {
        // warning message if more than one instance of this class exists, destroys the extra instance
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
        this.fileHandler = new FileHandler(Application.persistentDataPath, fileName, encryptionEnabled);
        this.dataManagementObjects = FindAllDataManagementObjects();
        LoadGame(); // loads the game data
    }

    // looks for all data management objects in the game
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

    // when a scene is loaded, load previous game data
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataManagementObjects = FindAllDataManagementObjects();
        LoadGame();
    }

    // when a scene is exited, save the game
    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    // creates a new instance of the GameData class
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    // saves game data to file
    public void SaveGame()
    {
        foreach (IDataManagement dataObject in dataManagementObjects)
        {
            dataObject.SaveData(gameData);
        }

        // debug messages for testing
        Debug.Log("Current saved puzzle points = " + gameData.puzzlePoints);
        Debug.Log("Current saved position = " + gameData.playerPosition);

        fileHandler.Save(gameData);
    }

    // loads game data from file
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

    // saves the game when the game is quit
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
