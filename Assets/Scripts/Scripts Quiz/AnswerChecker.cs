using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{


    //---------------this class is for checking if the clicked answer is correct ----------------------
    //------------ this is attached to every answer ----------------

    public QuestionDisplay questionDisplay;
    public Canvas correctCanvas;
    public Canvas falseCanvas;
	
	public AudioSource audioCorrect;
	public AudioSource audioWrong;

    //subscribe classes interested in the answer to this event (gamemanager, playerprefs?)
    public delegate void Answer(bool checkAnswerCorrect);
    public static event Answer GivenAnswer;

    public void OnAnswerClicked()
    {
        //we check the question present in the question display!
        if (questionDisplay.question.correctAnswer == name) //if the question's correct answer is equal to this button's value
        {          		
			correctCanvas.enabled = true;
			audioCorrect.Play();

			StartCoroutine(WaitCorrectScreen());
        }
        else
        {
            falseCanvas.enabled = true;
			audioWrong.Play();

			StartCoroutine(WaitFalseScreen());
        }
    }

    IEnumerator WaitCorrectScreen()
    {
        yield return new WaitForSeconds(2);
        GivenAnswer?.Invoke(true);

    }

    IEnumerator WaitFalseScreen()
    {
        yield return new WaitForSeconds(2);
        GivenAnswer?.Invoke(false);

    }



}
