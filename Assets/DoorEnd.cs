using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnd : MonoBehaviour
{
    public Rigidbody zamok;
    public GameObject canvas;
    public int scene;

    private void OnMouseOver()
    {
        if (zamok.isKinematic) return;
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
        if (zamok.isKinematic) return;
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 7f)
        {
            PlayerPrefs.SetInt("Win", 1);
            Application.LoadLevel(scene);
            Destroy(gameObject);
        }
    }
}
