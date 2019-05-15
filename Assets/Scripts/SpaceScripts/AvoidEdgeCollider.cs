using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidEdgeCollider : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "LaserBullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

    }
}
