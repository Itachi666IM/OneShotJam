using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    public GameObject charmBarrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(charmBarrier);
            Destroy(gameObject);
        }
    }
}
