using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool gameIsFrozen = false;

    private GameObject gameplayObjects;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        gameplayObjects = GameObject.Find("GameplayObjects");
    }

    private void Update()
    {
        if (gameIsFrozen)
            Time.timeScale = 0f;
        else if (!gameIsFrozen && !PauseMenu.GameIsPaused)
            Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);

        if (scene.name == "Menu" || scene.name == "Heaven")
        {
            gameplayObjects.SetActive(false);
        }
        else
            gameplayObjects.SetActive(true);
    }
}
