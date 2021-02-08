using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private bool isInRange;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
                interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
