using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

/*
 * This class is for dealing with the movement of puzzle pieces, and also contains some logic for changing the sprite layer and 
 * deciding if the pieces can be moved or not.
 * 
 * the OnMouseUp() and OnMouseDown() code for clicking and dragging game objects is from https://www.youtube.com/watch?v=uk_E_cGrlQc,
 * Drag and Drop System in Unity - Puzzle Game Example (PC and Mobile) by GameDevel on YouTube
 */
public class PieceMovement : MonoBehaviour
{
    // action to be invoked when a piece is placed
    public static Action OnPiecePlaced;

    private bool isMoving;

    private float startPosX;
    private float startPosY;

    public float sensitivity; // sensitivity is for how close the piece has to be to the right space before it snaps into place
    public List<GameObject> correspondingSpace;
    public bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;

    }

    // Update is called once per frame
    void Update()
    {

        // if the puzzle hasn't been completed
        if (PuzzleLogic.isComplete == false)
        {
            // if the piece is being moved
            if (isMoving == true)
            {
                isPlaced = false;
                gameObject.GetComponent<Renderer>().sortingOrder = 4; // set the sprite sorting order to be 4
                Vector3 mousePos;
                mousePos = Input.mousePosition; // mousePos equals the current position of the mouse cursor
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                // moves the piece to the same position as the mouse cursor
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }

        // if the piece is in the right place, set its sorting order to 2
        if (isPlaced == true && isMoving == false)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = 2;
        }
        else if (isPlaced == false && isMoving == false)
        {
            // if the piece isn't moving but isn't in the right place, set the sorting order to 3
            gameObject.GetComponent<Renderer>().sortingOrder = 3;
        }

    }

    // when the mouse button has been clicked on a puzzle piece, move the puzzle piece so the player can drag it across the screen
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
                return; // returns so that the pieces can't be picked up through UI elements
            }
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isMoving = true;

        }
    }

    // when the player lets go of a piece, check if it is in the right place 
    public void OnMouseUp()
    {
        isMoving = false;

        // if the piece position is very close to the right space, snap it into place and set is placed to true
        for (int i = 0; i < correspondingSpace.Count; i++)
        {
            if (Mathf.Abs(this.transform.localPosition.x - correspondingSpace[i].transform.localPosition.x) <= sensitivity && Mathf.Abs(this.transform.localPosition.y - correspondingSpace[i].transform.localPosition.y) <= sensitivity)
            {
                OnPiecePlaced?.Invoke();
                this.transform.position = new Vector3(correspondingSpace[i].transform.position.x, correspondingSpace[i].transform.position.y, correspondingSpace[i].transform.position.z);
                isPlaced = true;
            }
            //else
            //{
             //   isPlaced = false; this code broke the garden puzzle?
            //}
        }

    }
}
