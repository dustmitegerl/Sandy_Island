using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinManager : MonoBehaviour
{
    // toggle window between fullscreen and windowed
    public void ToggleWindow()
    {
        Debug.Log("toggling window");
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void CloseGame()
    {
        Debug.Log("quitting application");
        Application.Quit();
    }
    public void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //when escape is pressed
        {
            CloseGame();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartAgain();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleWindow();
        }

    }
}
