using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberDeadEnemies : MonoBehaviour
{
    public GameObject[] Enemies;
    public static int enemyCount = 5;

    // only happens when enemy is hit
    public void SaveEnemyDeath(string enemyName)
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (enemyName == Enemies[i].name && Enemies[i] != null)
            {
                Enemies[i].gameObject.SetActive(false);
                PlayerPrefs.SetString("Dead " + i, Enemies[i].name);
            }
         }
    }

    public static void ResetDeadEnemies() 
    {
        for (int i = 0; i < enemyCount; i++)
        {
            PlayerPrefs.DeleteKey("Dead " + i); 
        }

    }

    public void OnEnable()
    {
        TimeForAQuestion.EnemyHit += SaveEnemyDeath;

        for (int i = 0; i < Enemies.Length; i++)
        {
            if (PlayerPrefs.GetString("Dead " + i) == Enemies[i].name)
            {
                print("Dead: "+ Enemies[i].name + ", not setting active");
            }
            else
            {
                Enemies[i].SetActive(true);
            }
        }
    }

    public void OnDisable()
    {
        TimeForAQuestion.EnemyHit -= SaveEnemyDeath;
    }
}
