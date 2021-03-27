using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int maxrandom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Random.Range(0, maxrandom) == 0)
            {
                audioSource.PlayOneShot(audioClip);
                Destroy(this);
            }
        }
    }
}
