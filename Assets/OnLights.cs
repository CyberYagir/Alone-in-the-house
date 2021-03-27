using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class OnLights : MonoBehaviour
{
    public List<Light> lights;
    public GameObject canvas;
    public GameObject lamps;
    public Renderer okIndic;
    public Material ok;
    public GameObject m1, m2, pistol;
    private void OnMouseEnter()
    {
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
            lamps.SetActive(true);
            okIndic.material = ok;
            pistol.SetActive(true);
            var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 2);
            p.audioSource.PlayOneShot(p.audioSource.clip);
            m1.SetActive(false);
            m2.SetActive(true);
            canvas.SetActive(false);
            Destroy(this);
        }
    }
}
