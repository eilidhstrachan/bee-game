using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : VillageElement
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;
    public int puzzlePoints;
}