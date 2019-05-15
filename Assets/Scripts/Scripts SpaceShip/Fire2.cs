using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{
	public Transform firePoint1;
	public Transform firePoint2;
	public GameObject FirePrefab;

	// Start is called before the first frame update
	void Start()
	{

	}

	// This Script is responsible for the upward flame thingies
	void Update()
	{
		if (Input.GetButton("VerticalBackwards"))
		{
			StartFire();			
		}
	}

	void StartFire()
	{
		Instantiate(FirePrefab, firePoint1.position, firePoint1.rotation);
		Instantiate(FirePrefab, firePoint2.position, firePoint2.rotation);
	}
}
