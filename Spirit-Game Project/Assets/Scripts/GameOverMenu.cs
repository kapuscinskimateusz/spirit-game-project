using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;

    private bool isDisplayed = false;

    private void Update()
    {
        if (GameManager.instance.GameIsOver && !isDisplayed)
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        gameOverMenuUI.SetActive(true);
        GameManager.instance.GameIsFrozen = true;
    }

    private void HideUI()
    {
        gameOverMenuUI.SetActive(false);
        GameManager.instance.GameIsOver = false;
        GameManager.instance.GameIsFrozen = false;
    }

    public void Restart()
    {
        HideUI();
        LevelManager.instance.LoadCurrentLevel();
    }

    public void Quit()
    {
        HideUI();
        LevelManager.instance.LoadMenu();
    }
}
