using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TombstoneZoomUI : MonoBehaviour
{
    public Text tombstoneText;

    private void Start()
    {
        tombstoneText.text = "Ś.P.\n" +
            "Kasper\n" +
            "Spirit\n" +
            "ur. 07.01.2005 r.\n" +
            "zm. 07.01.2021 r.";
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
