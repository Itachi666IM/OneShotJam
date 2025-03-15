using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    Vector2 playerMovement;
    Rigidbody2D myRigidbody;

    public bool canMove;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    private void Update()
    {
        if(canMove)
        {
            Run();
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(playerMovement.x * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
}
