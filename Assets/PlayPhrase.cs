using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayPhrase : MonoBehaviour
{
    public int id;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == id);
            p.audioSource.PlayOneShot(p.audioSource.clip);
            Destroy(this);
        }
    }
}
