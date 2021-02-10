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

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToIntroduction()
    {
        HealthSystem.instance.Heal(HealthSystem.instance.maxHealth - HealthSystem.instance.CurrentHealth);
        SceneManager.LoadScene("Introduction");
    }

    public void GoToHell()
    {
        HealthSystem.instance.Heal(HealthSystem.instance.maxHealth - HealthSystem.instance.CurrentHealth);
        SceneManager.LoadScene("Hell");
    }

    public void GoToHeaven()
    {
        HealthSystem.instance.Heal(HealthSystem.instance.maxHealth - HealthSystem.instance.CurrentHealth);
        SceneManager.LoadScene("Heaven");
    }

    public void RestartLevel()
    {
        HealthSystem.instance.Heal(HealthSystem.instance.maxHealth - HealthSystem.instance.CurrentHealth);
        SceneManager.LoadScene(GetCurrentLevel());
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

        if (scene.name == "Menu" || scene.name == "Heaven")
        {
            gameplayObjects.SetActive(false);
        }
        else
            gameplayObjects.SetActive(true);
    }
}
