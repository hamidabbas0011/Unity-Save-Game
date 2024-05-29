using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
     
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;   
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; //Freeze the game
        isGamePaused = true;
    }
    public void Menu()
    {
        Save();
        SceneManager.LoadScene(0);
    }
    public void Save()
    {
        Debug.Log("This is Save");
    }
    public void Load()
    {
        Debug.Log("This is Load");
    }
}
