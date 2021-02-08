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

    public void Change(Question _question, GameObject talkingNpc)
    {
        question = _question;
        npcEvent = talkingNpc.GetComponent<NPC>().npcEvent;

        gameObject.SetActive(true);
        Initialize();
    }

    private void Initialize()
    {
        questionText.text = question.text;
        firstChoice.GetComponentInChildren<Text>().text = question.firstChoice;
        secondChoice.GetComponentInChildren<Text>().text = question.secondChoice;
    }

    public void OnAnswerYes()
    {
        EndQuestion();
        npcEvent.Invoke();
    }

    public void OnAnswerNo()
    {
        EndQuestion();
    }

    private void EndQuestion()
    {
        gameObject.SetActive(false);
        GameManager.instance.gameIsFrozen = false;
    }
}
