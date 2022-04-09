using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// piece movement code from https://www.youtube.com/watch?v=uk_E_cGrlQc,
// Drag and Drop System in Unity - Puzzle Game Example (PC and Mobile) by GameDevel on YouTube
public class PieceMovement : MonoBehaviour
{

    private bool isMoving;

    private float startPosX;
    private float startPosY;

    private bool finalPos;

    public GameObject correspondingSpace;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finalPos == false)
        {
            if (isMoving == true)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }

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

        if (Mathf.Abs(this.transform.localPosition.x - correspondingSpace.transform.localPosition.x) <= 0.05f && Mathf.Abs(this.transform.localPosition.y - correspondingSpace.transform.localPosition.y) <= 0.05f)
        {
            this.transform.position = new Vector3(correspondingSpace.transform.position.x, correspondingSpace.transform.position.y, correspondingSpace.transform.position.z);
            finalPos = true;
        }
    }
}
