using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{
    public TombstoneZoomUI tombstoneZoomUI;

    private bool isDisplayed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDisplayed)
        {
            tombstoneZoomUI.Hide();
            isDisplayed = false;

            GameManager.instance.GameIsFrozen = false;
        }
    }

    public void Zoom()
    {
        if (!isDisplayed)
        {
            tombstoneZoomUI.Show();
            isDisplayed = true;

            GameManager.instance.GameIsFrozen = true;
        }
    }
}
