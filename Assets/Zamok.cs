using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zamok : MonoBehaviour
{
    public GameObject canvas;
    private void OnMouseOver()
    {
        if (!GetComponent<Rigidbody>().isKinematic) return;
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 7f)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        canvas.SetActive(false);
    }
    private void OnDestroy()
    {
        canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!GetComponent<Rigidbody>().isKinematic) return;
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 7f)
        {
            if (FindObjectOfType<WeaponSwitch>().keyCan == true)
            {
                var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 8);
                p.audioSource.PlayOneShot(p.audioSource.clip);
                GetComponent<Rigidbody>().isKinematic = false;
                canvas.SetActive(false);
                Destroy(this);
            }
        }
    }
}
