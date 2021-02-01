using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameplayObjects;

    private void Awake()
    {
        gameplayObjects = GameObject.Find("GameplayObjects");
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

        if (scene.name == "Menu")
        {
            gameplayObjects.SetActive(false);
        }
        else
            gameplayObjects.SetActive(true);
    }
}
