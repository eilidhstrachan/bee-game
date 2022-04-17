using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IDataManagement
{
    public GameObject optionsMenu;
    public GameObject mayorLetter;
    public bool isLetterRead;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void SaveData(GameData data)
    {
        data.letterRead = isLetterRead;
    }
}
