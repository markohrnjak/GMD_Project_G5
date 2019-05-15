using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    // ------------- this class is for enemies, it makes them chase the player if the player gets into the aggro area ---------------

    public Transform Player;

    int moveSpeed = 50;              //speed with which to chase player
    int aggroRange = 220;

    //int distanceFromPlayer = 1;
    float currentDistance;

    void Update()
    {
        transform.right = Player.position - transform.position; //same as transform.LooAt just for 2D
        currentDistance = Vector2.Distance(transform.position, Player.position);

        if (currentDistance < aggroRange)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime; //move towards player
        }
        /*//We used an event to solve this argument
            if (currentDistance <= distanceFromPlayer) //if enemy gets  close
            {
                Debug.Log("Gotcha!");
            }
        */

    }
}