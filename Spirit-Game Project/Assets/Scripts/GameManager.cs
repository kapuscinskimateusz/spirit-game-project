using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool gameIsFrozen = false;
    public bool GameIsFrozen
    {
        get { return gameIsFrozen; }
        set
        {
            gameIsFrozen = value;
        }
    }

    private bool gameIsOver = false;
    public bool GameIsOver
    {
        get { return gameIsOver; }
        set
        {
            gameIsOver = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (gameIsFrozen)
            Time.timeScale = 0f;
        else if (!gameIsFrozen)
            Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
