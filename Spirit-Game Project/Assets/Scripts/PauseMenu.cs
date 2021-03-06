using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.GameIsOver)
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        GameManager.instance.GameIsFrozen = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        GameManager.instance.GameIsFrozen = true;
    }

    public void Restart()
    {
        Resume();
        LevelManager.instance.LoadCurrentLevel();
    }

    public void Quit()
    {
        Resume();
        LevelManager.instance.LoadMenu();
    }
}
