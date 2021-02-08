using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public Dialogue firstDialogue;
    public Dialogue everyNextOneDialogue;
    public UnityEvent npcEvent;

    private DialogueController dialogueController;

    private bool wasTalking = false;
    public bool WasTalking
    {
        get { return wasTalking; }
        set
        {
            wasTalking = value;
        }
    }

    private void Start()
    {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    public void Talk()
    {
        if (!wasTalking)
        {
            dialogueController.StartDialogue(firstDialogue, gameObject);
            wasTalking = true;
        }
        else
            dialogueController.StartDialogue(everyNextOneDialogue, gameObject);
    }
}
