using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    //This class can save, load and reset the position of referenced gameobject, right now it has its own empt object in scene

    public Transform PlayerP;

    // saves position when event Whereplayerwashit happened
    public void SavePosition(Transform PlayerPosition)
    {
        PlayerPrefs.SetFloat("x", PlayerPosition.position.x);
        PlayerPrefs.SetFloat("y", PlayerPosition.position.y);
        PlayerPrefs.SetFloat("z", PlayerPosition.position.z);
    }

    public Transform LoadPosition()
    {
        PlayerP.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z")); //for storing last position

        return PlayerP;
    }

    public static void ResetPosition()
    {
        PlayerPrefs.SetFloat("x", -3);
        PlayerPrefs.SetFloat("y", -88);
        PlayerPrefs.SetFloat("z", -7);
    }


    //-----------------------for subscribing events----------------------
    void OnEnable()
    {
        //subscribe to events here
        TimeForAQuestion.WherePlayerWasHit += SavePosition;

        //when this object is created (on scene load) it automatically puts you in the last remembered position
        LoadPosition();
    }

    void OnDisable()
    {
        //unsubscribe!
        TimeForAQuestion.WherePlayerWasHit -= SavePosition;
    }


}