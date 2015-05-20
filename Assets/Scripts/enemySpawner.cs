using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	public float spawnRate = 2f;
	public float startDelay = 2f;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn", startDelay, spawnRate );
	}

	void Spawn (){

		Instantiate( enemyToSpawn ,transform.position ,Quaternion.identity );


	}
}
