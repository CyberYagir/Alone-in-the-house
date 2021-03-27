using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Random.Range(0, 5) == 2)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<AudioSource>().PlayOneShot(audioClip);
                Destroy(this);
            }
        }
    }
}
