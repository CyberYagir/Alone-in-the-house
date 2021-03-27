using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRender : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;  
    }
}
