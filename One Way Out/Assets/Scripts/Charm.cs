using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    public GameObject charmBarrier;
    public AudioSource audioSource;
    public AudioClip charmPickup;
    public AudioClip barrierBreak;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.PlayOneShot(charmPickup);
            audioSource.PlayOneShot(barrierBreak);
            Destroy(gameObject);
            Destroy(charmBarrier);
        }
    }
}
