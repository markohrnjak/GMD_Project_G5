using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.



public class EndScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    private int finalScore = 0;
    void Start()
    {
        finalScoreText = gameObject.GetComponent<TextMeshProUGUI>();
        finalScore = PlayerPrefs.GetInt("Score");
        finalScoreText.text = "Score: " + finalScore;

    }
    void Update()
    {

        
    }


}
