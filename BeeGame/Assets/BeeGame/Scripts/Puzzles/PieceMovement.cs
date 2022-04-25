using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// piece movement code from https://www.youtube.com/watch?v=uk_E_cGrlQc,
// Drag and Drop System in Unity - Puzzle Game Example (PC and Mobile) by GameDevel on YouTube
public class PieceMovement : MonoBehaviour
{
    public static Action OnPiecePlaced;

    private bool isMoving;

    private float startPosX;
    private float startPosY;

    public float sensitivity;
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
        //if (isPlaced == false) this code makes it so that once a piece is in the right place, it cannot be moved again
        //{
        if (isMoving == true)
        {
            isPlaced = false;
            gameObject.GetComponent<Renderer>().sortingOrder = 4;
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }

        if (isPlaced == true && isMoving == false)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = 2;
        }
        else if (isPlaced == false && isMoving == false)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = 2;
        }

        //}

    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isMoving = true;
        }
    }

    public void OnMouseUp()
    {
        isMoving = false;

        for (int i = 0; i < correspondingSpace.Count; i++)
        {
            if (Mathf.Abs(this.transform.localPosition.x - correspondingSpace[i].transform.localPosition.x) <= sensitivity && Mathf.Abs(this.transform.localPosition.y - correspondingSpace[i].transform.localPosition.y) <= sensitivity)
            {
                OnPiecePlaced?.Invoke();
                this.transform.position = new Vector3(correspondingSpace[i].transform.position.x, correspondingSpace[i].transform.position.y, correspondingSpace[i].transform.position.z);
                isPlaced = true;

            }
        }

    }
}
