using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    float timer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //when escape is pressed
        {
            ToggleMenu(); //toggle menu
            timer += Time.deltaTime;//start timer
        }
        if (Input.GetKeyUp(KeyCode.Escape))//if released
        {
            timer = 0;//reset time
        }
        else if (timer >= 5f)//if held for 5s
        {
            CloseGame();//close game
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleWindow();
        }
    }
    // toggle window between fullscreen and windowed
    public void ToggleWindow()
    {
        Debug.Log("toggling window");
        Screen.fullScreen = !Screen.fullScreen;
    }

    // toggle canvas between active and not
    public void ToggleMenu()
    {
        Debug.Log("toggling menu");
        canvas.SetActive(!canvas.activeSelf);
        
    }

    public void CloseGame() {
        Debug.Log("quitting application");
        Application.Quit();
    }

    public void WinGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
