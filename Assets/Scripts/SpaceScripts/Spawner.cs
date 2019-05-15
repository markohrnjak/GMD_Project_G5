using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] Asteroid;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;

	void Start()
	{
		StartCoroutine(WaitSpawner());
	}

	void Update()
	{
		spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

	IEnumerator WaitSpawner()
	{
		while (!stop)
		{

			Vector3 spawnPosition = new Vector3(0,Random.Range(-800, 800), 0);
			Instantiate(Asteroid[0], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

			yield return new WaitForSeconds(spawnWait);
		}

	}
}
