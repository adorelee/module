﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject obstaclePrefab;
	public GameObject obstcalePrefab2;
	private Vector3 spawnPos = new Vector3(25, 0, 0);
	private float startDelay = 2;
	private float repeatRate = 2;
	private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SpawnObstacle()
	{
		if (playerControllerScript.gameOver == false)
		{
			int ranObj = Random.Range(0, 5);

            if (ranObj > 2)
            {
				Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
			}
            else if (ranObj <= 2)
            {
				Instantiate(obstcalePrefab2, spawnPos, obstaclePrefab.transform.rotation);
			}
			
			
		}
	}
}

