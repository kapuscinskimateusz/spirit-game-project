using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question, NPC> { }

public class DialogueController : MonoBehaviour
{
    public QuestionEvent questionEvent;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerLeftUI;
    private SpeakerUI speakerRightUI;

    private bool dialogueStarted = false;

    private Queue<Line> lines;
    private Question question;
    private NPC npc;

    private void Start()
    {
        speakerLeftUI = speakerLeft.GetComponent<SpeakerUI>();
        speakerRightUI = speakerRight.GetComponent<SpeakerUI>();

        lines = new Queue<Line>();
    }

    private void Update()
    {
        if (dialogueStarted && Input.GetKeyDown(KeyCode.Space) && !PauseMenu.GameIsPaused)
            AdvanceDialogue();
    }

    public void StartDialogue(Dialogue dialogue, GameObject _talkingNpc)
    {
        npc = _talkingNpc.GetComponent<NPC>();

        dialogueStarted = true;
        GameManager.instance.GameIsFrozen = true;

        lines.Clear();

        speakerLeftUI.Speaker = dialogue.speakerLeft;
        speakerRightUI.Speaker = dialogue.speakerRight;

        foreach (Line line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        question = dialogue.question;

        AdvanceDialogue();
    }

    private void AdvanceDialogue()
    {
        if (lines.Count == 0)
        {
            OnDialogueEnd();

            return;
        }

        DisplayLine();
    }

    private void DisplayLine()
    {
        Line line = lines.Dequeue();
        Character character = line.character;

        if (speakerLeftUI.SpeakerIs(character))
        {
            SetDialogue(speakerLeftUI, speakerRightUI, line.sentence);
        }
        else
        {
            SetDialogue(speakerRightUI, speakerLeftUI, line.sentence);
        }
    }

    private void OnDialogueEnd()
    {
        dialogueStarted = false;

        speakerLeftUI.Hide();
        speakerRightUI.Hide();

        questionEvent.Invoke(question, npc);
    }

    private void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.DialogueText = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
