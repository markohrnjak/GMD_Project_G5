using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRight : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed = 60f;
	public float i;
	public GameObject AsteroidExplosion;

	// Start is called before the first frame update
	void Start()
	{
		i = Random.Range(-1, 1);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(1, i, 0) * Time.deltaTime * speed);


	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Planets")
        {
            Instantiate(AsteroidExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Laserbullet")
        {
            Instantiate(AsteroidExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            int score=PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", score + 5);
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(AsteroidExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
