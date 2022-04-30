using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

/*
 * Script to handle to win condition logic of all the 
 * drag and drop style puzzles in the game 
 */
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


    // Start is called before the first frame update, initialises all the related variables and gameobjects 
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
        // if the puzzle isn't complete, check the piece positions and check if it is complete
        if (isComplete == false)
        {
            CheckPiece();
            CheckIfComplete();
        }

        // if puzzle is complete but finish hasn't been set to true yet, invoke the OnPuzzleCompleted action, call PuzzleCompleted() and set puzzle to true
        if (isComplete == true && finish == false)
        {

            OnPuzzleCompleted?.Invoke();
            PuzzleCompleted();
            finish = true;
            
        }

        // if puzzle is completed and finished, return
        if (isComplete == true && finish == true)
        {
            return;
        }


    }

    // checks to see if all the pieces are in the right place
    public void CheckPiece()
    {
        for (int i = 0; i < total; i++)
        {
            // if the piece is placed and to check is false, increment the point counter by one
            if (puzzlePieces[i].GetComponent<PieceMovement>().isPlaced == true && toCheck[i] == false)
            {
                toCheck[i] = true;
                pointCounter++;
                Debug.Log("Counter =" + pointCounter);
            }
            else if (puzzlePieces[i].GetComponent<PieceMovement>().isPlaced == false && toCheck[i] == true)
            { 
                // if the piece isn't placed but it has been previously checked as being in the right place, set to check back to false and take away one point from the counter
                toCheck[i] = false;
                pointCounter--;
                Debug.Log("Counter =" + pointCounter);
            }
        }

    }

    // if the number of points is equal to the total required for the puzzle to be complete, set isComplete to true
    public void CheckIfComplete()
    {
        if (pointCounter == total)
        {
            isComplete = true;
        }
    }

    // if the puzzle is complete, display the win message UI and increment the player's puzzle point count by one
    public void PuzzleCompleted()
    {
        Debug.Log("Puzzle Complete!");
        winMessage.SetActive(true);
        PointsManager.playerPoints++;
        Debug.Log("Player Points" + PointsManager.playerPoints);
    }

    public void LoadData(GameData data)
    {
        // get puzzle data from gamedata file
        data.puzzles.TryGetValue(puzzleID, out finish);
        if (finish == true)
        {
            this.gameObject.SetActive(false);  // if puzzle is already finished, set puzzle logic to be not active

        }
    }

    public void SaveData(GameData data)
    {
        if (data.puzzles.ContainsKey(puzzleID))
        {
            data.puzzles.Remove(puzzleID);
        }

        // save puzzle data to game data file
        data.puzzles.Add(puzzleID, finish);
    }

}
