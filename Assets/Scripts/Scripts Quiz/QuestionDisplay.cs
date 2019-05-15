using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//--------------this class helps to display the content of a question (question + answers)-------------------
public class QuestionDisplay : MonoBehaviour
{
    public Question question;

    public TextMeshProUGUI questionDisplay;

    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    // Start is called before the first frame update
    void Start()
    {
        questionDisplay.text = question.question;

        answer1.text = question.answer1;
        answer2.text = question.answer2;
        answer3.text = question.answer3;
        answer4.text = question.answer4;

    }

}
