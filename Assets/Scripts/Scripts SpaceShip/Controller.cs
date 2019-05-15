using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public float moveSpeed = 75f;
	public float moveSmooth = .3f;

	private Rigidbody2D rb;

	Vector2 velocity = Vector2.zero;
	Vector2 movement = Vector2.zero;

	Vector2 mousePos = Vector2.zero;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private void FixedUpdate()
	{
		Vector2 desiredVelocity = movement * moveSpeed;
		rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSpeed);

		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;

	}
}

