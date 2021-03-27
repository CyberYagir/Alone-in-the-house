using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public GameObject canvas;
    public Transform[] poses;
    private void Start()
    {
        transform.position = poses[Random.Range(0, poses.Length)].position;
    }
    private void OnMouseOver()
    {
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
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 7f)
        {
            FindObjectOfType<WeaponSwitch>().keyCan = true;
            var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 6);
            p.audioSource.PlayOneShot(p.audioSource.clip);

            canvas.SetActive(false);
            Destroy(gameObject);
        }
    }
}
