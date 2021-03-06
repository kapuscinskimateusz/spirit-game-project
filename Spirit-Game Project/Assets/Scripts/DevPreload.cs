using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Menu");
    }
}
