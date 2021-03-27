using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    public GameObject menu;
    public Slider slider;
    public PlayerMove playerMove;
    public Pistol pistol;
    public HandLight light;
    public TMPro.TMP_Text sense;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("sens", 1);
    }
    public void Update()
    {
        sense.text = slider.value.ToString("F2");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.active);
            pistol.enabled = !menu.active;
            light.enabled = !menu.active;
            playerMove.enabled = !menu.active;
            if (menu.active)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            Time.timeScale = menu.active ? 0 : 1;
        }
    }
    public void Exit()
    {
        Application.LoadLevel(0);
    }
    public void ChangeSense()
    {
        playerMove.sens = slider.value;
        PlayerPrefs.SetFloat("sens", slider.value);
    }
}
