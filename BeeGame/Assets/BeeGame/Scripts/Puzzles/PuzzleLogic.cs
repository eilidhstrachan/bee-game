using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PuzzleLogic : MonoBehaviour, IDataManagement
{
    public static Action OnPuzzleCompleted;

    public GameObject[] puzzlePieces;
    public GameObject winMessage;
    public GameObject puzzleInstructions;

    public int puzzleID;

    private int total;
    private int pointCounter;
    public static bool isComplete;
    private bool[] toCheck;
    private bool finish;


    // Start is called before the first frame update
    void Start()
    {
        puzzleInstructions.SetActive(true);
        winMessage.SetActive(false);

        isComplete = false;
        finish = false;

        pointCounter = 0;

        total = puzzlePieces.Length;
        Debug.Log("Total = "+ total);

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
            CheckPiece();
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

    public void CheckPiece()
    {
        for (int i = 0; i < total; i++)
        {
            if (puzzlePieces[i].GetComponent<PieceMovement>().isPlaced == true && toCheck[i] == false)
            {
                toCheck[i] = true;
                pointCounter++;
                Debug.Log("Counter =" + pointCounter);
            }
            else if (puzzlePieces[i].GetComponent<PieceMovement>().isPlaced == false && toCheck[i] == true)
            {
                toCheck[i] = false;
                pointCounter--;
                Debug.Log("Counter =" + pointCounter);
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
