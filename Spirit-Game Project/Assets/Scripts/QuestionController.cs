using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text questionText;
    public Button firstChoice, secondChoice;

    private Question question;
    private UnityEvent npcEvent;

    public void Change(Question _question, NPC _npc)
    {
        question = _question;
        npcEvent = _npc.npcEvent;

        gameObject.SetActive(true);
        Initialize();
    }

    private void Initialize()
    {
        questionText.text = question.text;
        firstChoice.GetComponentInChildren<Text>().text = question.firstChoice;
        secondChoice.GetComponentInChildren<Text>().text = question.secondChoice;
    }

    public void AnswerYes()
    {
        EndQuestion();
        npcEvent.Invoke();
    }

    public void AnswerNo()
    {
        EndQuestion();
    }

    private void EndQuestion()
    {
        gameObject.SetActive(false);
        GameManager.instance.GameIsFrozen = false;
    }
}
