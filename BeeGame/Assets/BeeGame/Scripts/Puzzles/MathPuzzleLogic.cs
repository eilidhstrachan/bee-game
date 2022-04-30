using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

/*
 * Seperate puzzle logic class for the maths puzzle, since it isn't a drag and drop puzzle
 * like the others.
 */
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
        puzzleInstructions.SetActive(true); // show the puzzle instructions

        winMessage.SetActive(false); // hide the win message

        isComplete = false;
        finish = false;

        pointCounter = 0;

        // set the total required to complete the puzzle to be the number of input fields
        total = inputFields.Count;
        Debug.Log("Total = " + total);

        // instantiates all toCheck values to be false as the input fields all still need to be checked
        toCheck = new bool[total];
        for (int i = 0; i < total; i++)
        {
            toCheck[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the puzzle isn't complete, check the input fields and check if it is complete
        if (isComplete == false)
        {
            CheckInputFields();
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

    // checks each input field to see if the correct answer has been inputted
    public void CheckInputFields()
    {
        for (int i = 0; i < total; i++)
        {
            temp = inputFields[i].text; // variable to hold the input field value

            // if current input field still needs to be checked
            if (toCheck[i] == false)
            {
                // if the current input field is the first one and the player has entered 5
                if (i == 0 && (temp.Equals("5") || temp.Equals("five")))
                {
                    // increment point counter by one and set to check to true
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for hive!");
                }
                else if (i == 1 && (temp.Equals("4") || temp.Equals("four"))) // if the current input field is the 2nd one and the player has entered 4
                {
                    // increment point counter by one and set to check to true
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for jar!");
                }
                else if (i == 2 && (temp.Equals("2") || temp.Equals("two"))) // if the current input field is the 3rd one and the player has entered 2
                {
                    // increment point counter by one and set to check to true
                    toCheck[i] = true;
                    pointCounter++;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Right answer for bee!");
                }
            }
            else if (toCheck[i] == true) // if current input field has already been checked and had the right answer, make sure the player hasn't changed their answer
            {
                // if player changed the first answer to be wrong
                if (i == 0 && !(temp.Equals("5") || temp.Equals("five")))
                {
                    // change to check back to false and remove one point from the counter
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for hive!");
                }
                else if (i == 1 && !(temp.Equals("4") || temp.Equals("four"))) // if player changed the 2nd answer to be wrong
                {
                    // change to check back to false and remove one point from the counter
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for jar!");
                }
                else if (i == 2 && !(temp.Equals("2") || temp.Equals("two"))) // if player changed the 3rd answer to be wrong
                {
                    // change to check back to false and remove one point from the counter
                    toCheck[i] = false;
                    pointCounter--;
                    Debug.Log("Counter =" + pointCounter);
                    Debug.Log("Wrong answer for bee!");
                }
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

        // if puzzle is already finished, set puzzle logic to be not active
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

        // save puzzle data to game data file
        data.puzzles.Add(puzzleID, finish);
    }

}
