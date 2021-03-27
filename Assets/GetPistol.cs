using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetPistol : MonoBehaviour
{
    public GameObject canvas;
    public GameObject m2, m3;

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
            FindObjectOfType<WeaponSwitch>().pistolCan = true;
            var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 4);
            p.audioSource.PlayOneShot(p.audioSource.clip);
            m2.SetActive(false);
            m3.SetActive(true);
            canvas.SetActive(false);
            Destroy(gameObject);
        }
    }

}
