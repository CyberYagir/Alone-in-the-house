using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase : MonoBehaviour
{
    public AudioSource audioSource;
    public int phraseID;
    public GameObject sub;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        sub.SetActive(audioSource.isPlaying);
    }

}
