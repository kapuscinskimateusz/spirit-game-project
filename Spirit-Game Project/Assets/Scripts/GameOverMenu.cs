using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    private bool isDisplayed = false;

    private void Update()
    {
        if (GameManager.instance.gameIsOver && !isDisplayed)
            ShowUI();
        else if (!GameManager.instance.gameIsOver && isDisplayed)
            HideUI();
    }

    public void Restart()
    {
        GameManager.instance.gameIsOver = false;
        LevelManager.instance.RestartLevel();
    }

    public void Quit()
    {
        GameManager.instance.gameIsOver = false;
        LevelManager.instance.GoToMenu();
    }

    private void ShowUI()
    {
        gameOverUI.SetActive(true);
        isDisplayed = true;
        GameManager.instance.gameIsFrozen = true;
    }

    private void HideUI()
    {
        gameOverUI.SetActive(false);
        isDisplayed = false;
        GameManager.instance.gameIsFrozen = false;
    }
}
