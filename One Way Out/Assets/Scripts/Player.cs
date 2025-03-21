using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Vector2 playerMovement;
    Rigidbody2D myRigidbody;
    Animator anim;

    public bool canMove;

    
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if(Mathf.Abs(playerVelocity.x)>0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void MenuToPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
