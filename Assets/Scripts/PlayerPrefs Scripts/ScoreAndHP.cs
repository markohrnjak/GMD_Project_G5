using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreAndHP : MonoBehaviour
{ 
    private readonly int deathHP = 0; // you die with 0 health
    public Text HPDisplay;
    public Text ScoreDisplay;

    public delegate void Lost();
    public static event Lost LoseGame;

    public void Update()
    {
        HPDisplay.text = PlayerPrefs.GetInt("HP").ToString() + " HP";
        ScoreDisplay.text = "Score = "+PlayerPrefs.GetInt("Score").ToString();

        if (PlayerPrefs.GetInt("HP") <= deathHP)
        {
            LoseGame?.Invoke(); //tell listeners that the game is lost
        }
    }

    public void OnEnable() 
    {
        AnswerChecker.GivenAnswer += SaveScore;

    }

//save score on question answer, if you answer wrong you lose 1 health, method triggers when answer is given
    public void SaveScore(bool answerCorrect)
    {
        AnswerChecker.GivenAnswer -= SaveScore;

        int oldScore = PlayerPrefs.GetInt("Score");
        int oldHealth = PlayerPrefs.GetInt("HP");

        if(!answerCorrect)
        {
            oldHealth = oldHealth - 1;

            PlayerPrefs.SetInt("HP", oldHealth);

        }
        else
        {
            PlayerPrefs.SetInt("Score", oldScore + 10);
        }
    }

    //------resets
    public static void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public static void ResetHP()
    {
        PlayerPrefs.SetInt("HP", 3);
    }

}
