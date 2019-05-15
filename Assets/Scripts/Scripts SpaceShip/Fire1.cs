using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
	public Transform firePoint;
	public GameObject FirePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	// This Script is responsible for the downward flame
	void Update()
    {
		if (Input.GetButton("VerticalForward"))
		{
			StartFire();			
		}
    }

	void StartFire()
	{
		Instantiate(FirePrefab, firePoint.position, firePoint.rotation);		
	}

}
