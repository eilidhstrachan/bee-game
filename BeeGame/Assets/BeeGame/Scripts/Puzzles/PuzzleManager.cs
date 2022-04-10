using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<PuzzleLogic> puzzleList;

    // Start is called before the first frame update
    void Start()
    {
        puzzleList = new List<PuzzleLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
