using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGen : MonoBehaviour
{
	public string seed;
	public Vector3 mapSize;
	public GameObject player;
	System.Random random;
	int randomPos;


	void Start()
	{
		random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
		SpawnBall();
	}

	void SpawnBall()
	{

		randomPos = Random.Range(2,10);
		Vector3 spawnBall = new Vector3(Random.Range(mapSize.x / 2, mapSize.x / 2),1, Random.Range(mapSize.z / 2, mapSize.z / 2));
		Instantiate(player, spawnBall + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
	}
}