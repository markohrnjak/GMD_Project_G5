using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //----------------------this class is attached to the main camera in every scene---------------------

    private int mainMenu = 0;
    private int questionScreen = 1; //set to calue of scene where question's are made
    private int level1 = 2;
    private int gameOver = 3;
    private int explanation =4;
    private int win = 5;

    //----

    public void Explanation()
    {
        SceneManager.LoadScene(explanation);
    }
    public void NewGame()
    {
        //reset all of the stored data before loading up level
        RememberDeadEnemies.ResetDeadEnemies();
        PlayerPosition.ResetPosition();
        ScoreAndHP.ResetHP();
        ScoreAndHP.ResetScore();

        SceneManager.LoadScene(level1);
        Time.timeScale = 1; //so if you're coming from pause screen it unpauses time

    }

    //this method happens when you reach -3 health in ScoreAndHP
    public void GameOver()
    {     
        SceneManager.LoadScene(gameOver);
    }

	public void Quit()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1; //so if you're coming from pause screen it unpauses time

    }

    public void WinScreen()
    {
        SceneManager.LoadScene(win);
    }

	void OnPlayerAnswer(bool checkAnswerCorrect)
    {
        //for when player answers a question //--checking true is a remnant, there was originally a true and a false scene
        if (checkAnswerCorrect == true)
        {
            SceneManager.LoadScene(level1);
        }
        else if (checkAnswerCorrect == false)
        {
            SceneManager.LoadScene(level1);
        }

    }

    void QuestionScreenDisplay(string enemyName)
    {
        //for enemyhit event
        SceneManager.LoadScene(questionScreen);
    }

    //----

    //Event stuff happening here, if the player hits an enemy they get taken to the question scene
    //also checking if the player's answer was correct or not

    void OnEnable() // method that will be called whenever the object that this script is attached to, is created or enabled in the scene
    {
        //subscribe to events here
        TimeForAQuestion.EnemyHit += QuestionScreenDisplay;
        AnswerChecker.GivenAnswer += OnPlayerAnswer;
        ScoreAndHP.LoseGame += GameOver;
    }

    void OnDisable() // when object is destroyed or disabled
    {
        //unsubscribe!
        TimeForAQuestion.EnemyHit -= QuestionScreenDisplay;
        AnswerChecker.GivenAnswer -= OnPlayerAnswer;
        ScoreAndHP.LoseGame -= GameOver;

    }

    //----
}
