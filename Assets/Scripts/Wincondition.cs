using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wincondition : MonoBehaviour
{
   public int winScene = 4;

   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Earth")
        {
            SceneManager.LoadScene(winScene);
        }
    }
}
