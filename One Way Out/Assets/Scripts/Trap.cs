using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;
    bool changeDirection;
    
    void Update()
    {
        if(!changeDirection)
        {
            MoveTowadsLocation(pointB);
        }
        else
        {
            MoveTowadsLocation(pointA);
        }
        if (Vector2.Distance(transform.position, pointB.position) < 0.5f)
        {
            changeDirection = true;
        }
        if( Vector2.Distance(transform.position, pointA.position) < 0.5f)
        {
            changeDirection = false;
        }
    }

    void MoveTowadsLocation(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
