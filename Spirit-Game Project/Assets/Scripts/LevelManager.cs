using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    private GameObject gameplayObjects;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        gameplayObjects = GameObject.Find("GameplayObjects");
    }

    public void LoadIntroduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void LoadHell()
    {
        SceneManager.LoadScene("Hell");
    }

    public void LoadHellBoss()
    {
        SceneManager.LoadScene("Hell_Boss");
    }

    public void LoadHeaven()
    {
        SceneManager.LoadScene("Heaven");
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(GetCurrentLevel());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    private int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
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

        if (scene.name == "Menu" || scene.name == "Heaven" || scene.name == "Credits")
        {
            gameplayObjects.SetActive(false);
        }
        else
        {
            gameplayObjects.SetActive(true);
            HealthManager.instance.ResetHealth();
        }
    }
}

