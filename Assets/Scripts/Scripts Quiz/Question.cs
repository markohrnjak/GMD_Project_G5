using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------this class can make questions, try right click > create > Question--------------
[CreateAssetMenu(fileName = "New Question", menuName = "Question")]

public class Question : ScriptableObject
{
    public string question;

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public string correctAnswer;

}
