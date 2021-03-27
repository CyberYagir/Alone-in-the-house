using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image run;
    public PlayerMove playerMove;



    private void Update()
    {
        run.transform.localScale = new Vector3((playerMove.stamina / playerMove.maxStamina), 1);
    }
}
