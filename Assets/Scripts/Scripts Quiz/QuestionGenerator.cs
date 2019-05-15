using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public Question[] questionList; //put questions in here
    public QuestionDisplay quizTable;      //put where you want to inject the question
    int index;

    //---------------this class loads a random question eveery time the quiz scene pops up---------------------
    //---------------it is attached to the main camera!

    public void OnEnable()
    {
        index = Random.Range(0, questionList.Length);

        quizTable.question = questionList[index];
    }
}
