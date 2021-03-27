using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject win;
    private void Start()
    {
        win.SetActive(PlayerPrefs.HasKey("Win"));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Play()
    {
        Application.LoadLevelAsync(1);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
