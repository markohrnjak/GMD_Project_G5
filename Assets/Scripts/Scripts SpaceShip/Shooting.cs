using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform firePoint1;
	public Transform firePoint2;
	public GameObject BulletPrefab;

	// This Script is responsible for Shooting
	void Update()
	{
		if (Input.GetButtonDown("Fire"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		Instantiate(BulletPrefab, firePoint1.position, firePoint1.rotation);
		Instantiate(BulletPrefab, firePoint2.position, firePoint2.rotation);
	}

}
