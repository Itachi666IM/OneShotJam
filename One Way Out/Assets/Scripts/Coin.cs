using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    public AudioClip coinPickup;
    public AudioSource audioSource;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.PlayOneShot(coinPickup);
            player.isTimeSlowed = true;
            Destroy(gameObject);
        }
    }
}
