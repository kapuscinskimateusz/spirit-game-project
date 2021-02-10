using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.gameIsOver)
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
        GameManager.instance.gameIsFrozen = false;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameManager.instance.gameIsFrozen = true;
        GameIsPaused = true;
    }

    public void Restart()
    {
        LevelManager.instance.RestartLevel();
        Resume();
    }

    public void Quit()
    {
        LevelManager.instance.GoToMenu();
        Resume();
    }
}
