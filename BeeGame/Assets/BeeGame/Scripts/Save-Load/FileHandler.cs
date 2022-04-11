using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

// code for FileHandler is from How to make a Save & Load System in Unity | 2022, https://www.youtube.com/watch?v=aUi9aijvpgs by Trevor Mock
public class FileHandler
{
    private string directoryPath = "";
    private string fileName = "";

    public FileHandler(string directoryPath, string fileName)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
    }

    public void Save(GameData data)
    {
        string path = Path.Combine(directoryPath, fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string saveData = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(saveData);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Found error when attempting to save to file: "+ path + "\n" + e);
        }
    }

    public GameData Load()
    {
        GameData loadData = null;
        string path = Path.Combine(directoryPath, fileName);
        try
        {
            string dataToLoad = "";
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            loadData = JsonUtility.FromJson<GameData>(dataToLoad);

        }
        catch (Exception e)
        {
            Debug.LogError("Found error when attempting to save to file: " + path + "\n" + e);
        }
        return loadData;
    }

}
