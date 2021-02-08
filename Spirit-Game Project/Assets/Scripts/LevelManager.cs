using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void GoToIntroduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void GoToHell()
    {
        SceneManager.LoadScene("Hell");
    }

    public void GoToHeaven()
    {
        SceneManager.LoadScene("Heaven");
    }
}
