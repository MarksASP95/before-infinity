using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickUp : MonoBehaviour
{

    public AudioSource AudioSrc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AudioSrc.Play();
            Destroy(gameObject);        
        }
    }
}
