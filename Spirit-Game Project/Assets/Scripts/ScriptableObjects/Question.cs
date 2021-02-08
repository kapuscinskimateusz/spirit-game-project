using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public string firstChoice, secondChoice;
}
