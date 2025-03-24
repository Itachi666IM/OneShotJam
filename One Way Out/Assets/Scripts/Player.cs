using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public LayerMask groundLayer;
    public Transform groundCheck;
    Vector2 playerMovement;
    Rigidbody2D myRigidbody;
    Animator anim;

    public bool canMove;
    bool isGrounded;

    public bool isTimeSlowed;
    public float slowDownTime;
    public float slowedDownPlayerSpeed;
    float defaultSpeed;
    
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        defaultSpeed = speed;
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
        {
            anim.SetTrigger("jump");
            myRigidbody.velocity = Vector2.up * jumpSpeed;
        }
    }


    private void Update()
    {
        if(canMove)
        {
            Run();
            isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.5f,groundLayer);
        }
        else
        {
            isGrounded=false;
        }

        if(isTimeSlowed)
        {
            StartCoroutine(SlowDownTime());
            speed = slowedDownPlayerSpeed;
        }
        else
        {
            speed = defaultSpeed;
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

    IEnumerator SlowDownTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(slowDownTime);
        isTimeSlowed = false;
        Time.timeScale = 1f;
    }
}
