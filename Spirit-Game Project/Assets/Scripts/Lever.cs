using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject blockade;
    public Sprite leverOff;
    public Sprite leverOn;
    private SpriteRenderer spriteRenderer;

    private bool isTurnedOn = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Use()
    {
        isTurnedOn = !isTurnedOn;

        if (isTurnedOn)
        {
            spriteRenderer.sprite = leverOn;
            blockade.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = leverOff;
            blockade.SetActive(true);
        }
    }
}
