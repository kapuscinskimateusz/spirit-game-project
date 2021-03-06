using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
    public Line[] lines;
    public Question question;
}

[System.Serializable]
public struct Line
{
    public Character character;
    [TextArea(3, 10)]
    public string sentence;
}

