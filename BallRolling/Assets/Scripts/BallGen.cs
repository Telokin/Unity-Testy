using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGen : MonoBehaviour
{
	public GameObject[] Spawn;
	public Transform spawnPos;

	int randomInt =1;

	void Start()
	{
		SpawnRandom();
	}
	// Update is called once per frame
	void Update()
	{

	}

	void SpawnRandom()
	{
		randomInt = Random.Range(0, Spawn.Length);
		Instantiate(Spawn[randomInt], spawnPos.position, spawnPos.rotation);
	}
}