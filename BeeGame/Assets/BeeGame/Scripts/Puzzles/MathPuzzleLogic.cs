using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MathPuzzleLogic : MonoBehaviour, IDataManagement
{
    public static Action OnPuzzleCompleted;

    public GameObject winMessage;
    public GameObject puzzleInstructions;
    public List<TMP_InputField> inputFields;

    public int puzzleID;

    private int total;
    private int pointCounter;
    public static bool isComplete;
    private bool[] toCheck;
    private bool finish;
    private string temp;


    // Start is called before the first frame update
    void Start()
    {
        puzzleInstructions.SetActive(true);

        winMessage.SetActive(false);

        isComplete = false;
        finish = false;

        pointCounter = 0;

        total = inputFields.Count;
        Debug.Log("Total = " + total);

        toCheck = new bool[total];
        for (int i = 0; i < total; i++)
        {
            toCheck[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isComplete == false)
        {
            CheckInputFields();
            CheckIfComplete();
        }

        if (isComplete == true && finish == false)
        {

            OnPuzzleCompleted?.Invoke();
            PuzzleCompleted();
            finish = true;

        }

        if (isComplete == true && finish == true)
        {
            return;
        }


    }

    public void CheckInputFields()
    {
        for (int i = 0; i < total; i++)
        {
            temp = inputFields[i].text;
            if (toCheck[i] == false)
            {
                if (i == 0 && (temp.Equals("5") || temp.Equals("five")))
                {
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for hive!");
                }
                else if (i == 1 && (temp.Equals("4") || temp.Equals("four")))
                {
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for jar!");
                }
                else if (i == 2 && (temp.Equals("2") || temp.Equals("two")))
                {
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for bee!");
                }
            }
            else if (toCheck[i] == true)
            {
                if (i == 0 && !(temp.Equals("5") || temp.Equals("five")))
                {
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for hive!");
                }
                else if (i == 1 && !(temp.Equals("4") || temp.Equals("four")))
                {
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for jar!");
                }
                else if (i == 2 && !(temp.Equals("2") || temp.Equals("two")))
                {
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for bee!");
                }
            }
        }

    }

    public void CheckIfComplete()
    {
        if (pointCounter == total)
        {
            isComplete = true;
        }
    }

    public void PuzzleCompleted()
    {
        Debug.Log("Puzzle Complete!");
        winMessage.SetActive(true);
        PointsManager.playerPoints++;
        Debug.Log("Player Points" + PointsManager.playerPoints);
    }

    public void LoadData(GameData data)
    {
        data.puzzles.TryGetValue(puzzleID, out finish);
        if (finish == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.puzzles.ContainsKey(puzzleID))
        {
            data.puzzles.Remove(puzzleID);
        }

        data.puzzles.Add(puzzleID, finish);
    }

}
