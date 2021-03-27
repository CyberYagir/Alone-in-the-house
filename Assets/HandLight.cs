using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLight : MonoBehaviour
{
    public Transform camera;
    public float speed;

    void Update()
    {
        transform.position = camera.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, camera.rotation, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }
}
