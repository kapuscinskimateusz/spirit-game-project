using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool gameIsFrozen = false;
    public bool gameIsOver = false;
    public Vector2 lastCheckPointPos;

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

    public void GameOver()
    {
        gameIsOver = true;
    }
}
