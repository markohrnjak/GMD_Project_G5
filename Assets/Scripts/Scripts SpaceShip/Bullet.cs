using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed = 40f;
	public Rigidbody2D rb;
	public GameObject BulletExplosion;

	// Start is called before the first frame update
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D onCollision)
	{

		//Debug.Log(hitInfo.name);
		Instantiate(BulletExplosion, transform.position, transform.rotation);
		Destroy(gameObject);

	}
}
