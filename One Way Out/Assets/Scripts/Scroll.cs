using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject portal;
    public AudioClip scrollSound;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.PlayOneShot(scrollSound);
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
