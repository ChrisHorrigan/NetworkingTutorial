﻿using UnityEngine;
using System.Collections;

public class SpawnerCode : MonoBehaviour {

	public Transform cubePrefab;
	
	void OnServerInitialized()
	{
		SpawnPlayer();
	}
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	void SpawnPlayer()
	{
		Transform myTransform = (Transform)Network.Instantiate(cubePrefab, transform.position, transform.rotation, 0);
	}
}
