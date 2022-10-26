using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables for Movement Controls
    public bool CanMove;
    public PlayerNum PlayerNum;
    private Vector2 MoveInput;
    private Vector2 moveDirection;

    //Speed Variables
    public float moveSpeed = 5f;
    private float currentSpeed;
    public Rigidbody2D rb;

    //Active Ability
    public ActiveAbility CurrentAbility;

    private void Start()
    {
        CanMove = true;
    }

    private void Update()
    {
        if (PlayerNum == PlayerNum.Player1)
        {
            MoveInput.x = Input.GetAxisRaw("Player 1 Horizontal");
            MoveInput.y = Input.GetAxisRaw("Player 1 Vertical");
        }
        else if (PlayerNum == PlayerNum.Player2)
        {
            MoveInput.x = Input.GetAxisRaw("Player 2 Horizontal");
            MoveInput.y = Input.GetAxisRaw("Player 2 Vertical");
        }

        if (MoveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (MoveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (CanMove == true)
        {
            moveDirection = MoveInput.normalized;

            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void ActiveAbility()
    {
        switch (CurrentAbility)
        {
            case global::ActiveAbility.PushBlock:
                break;
            case global::ActiveAbility.Dash:
                break;
            default:
                break;
        }
    }
}

public enum PlayerNum
{
    Player1 = 0,
    Player2 = 1
}

public enum ActiveAbility
{
    None,
    PushBlock,
    Dash,
}

