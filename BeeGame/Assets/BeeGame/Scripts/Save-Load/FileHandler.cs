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
    private readonly string encryptionKey = "sea";
    private bool encryptionEnabled = false;

    public FileHandler(string directoryPath, string fileName, bool encryptionEnabled)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
        this.encryptionEnabled = encryptionEnabled;
    }

    public void Save(GameData data)
    {
        string path = Path.Combine(directoryPath, fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string saveData = JsonUtility.ToJson(data, true);

            if (encryptionEnabled == true)
            {
                saveData = Encryption(saveData);
            }

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

            if (encryptionEnabled == true)
            {
                dataToLoad = Encryption(dataToLoad);
            }

            loadData = JsonUtility.FromJson<GameData>(dataToLoad);

        }
        catch (Exception e)
        {
            Debug.LogError("Found error when attempting to save to file: " + path + "\n" + e);
        }
        return loadData;
    }

    private string Encryption(string data)
    {
        string encryptedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            encryptedData += (char)(data[i] ^ encryptionKey[i % encryptionKey.Length]);
        }
        return encryptedData;
    }

}
