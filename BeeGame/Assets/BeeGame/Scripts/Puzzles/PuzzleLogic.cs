using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLogic : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] emptySpaces;

    private int total;
    private int[] hasChecked;
    private bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        isComplete = false;

        int[] hasChecked = new int[puzzlePieces.Length];

        for (int index = 0; index < puzzlePieces.Length; index++)
        {
            hasChecked[index] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].transform.position == emptySpaces[i].transform.position)
            {
                hasChecked[i] = i;
                total++;
                Debug.Log("Total = " + total);
                Debug.Log("Has checked = " + hasChecked[i]);
            }
        }

        if (total == puzzlePieces.Length)
        {
            isComplete = true;
            Debug.Log("Puzzle completed!! = " + isComplete);
        }
    }
}
