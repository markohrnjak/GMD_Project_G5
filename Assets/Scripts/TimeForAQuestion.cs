using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeForAQuestion : MonoBehaviour
{
    //-------------------- this class is for checking foreign object hits on player -------------------------------
    //-------------------- this class is attached to the player -------------------------------


    //event for observers to subscribe to
    public delegate void WasHit(string enemyName);
    public static event WasHit EnemyHit;

    public delegate void LastPosition(Transform PlayerPosition);
    public static event LastPosition WherePlayerWasHit;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //event! -- notify observers (gamemanager) about hit
            WherePlayerWasHit?.Invoke(gameObject.transform);
            EnemyHit?.Invoke(other.gameObject.name);

        }
    }
}
