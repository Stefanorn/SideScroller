﻿using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	public float spawnRate = 2f;
	public float startDelay = 2f;
	public bool singleSpawn = false;

	// Use this for initialization
	void Start () 
	{
		if(singleSpawn){
			Invoke("SingleSpawn",startDelay);
		}
		else {
			InvokeRepeating("Spawn", startDelay, spawnRate );
		}
	}
	void FixedUpdate() {
		if( GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().RespawnSingleEnemys() ){
			Invoke("SingleSpawn",startDelay);
		}

	}
	void Spawn (){

		Instantiate( enemyToSpawn ,transform.position ,Quaternion.identity );
	}
	void SingleSpawn(){
		Instantiate( enemyToSpawn ,transform.position ,Quaternion.identity );
	}
}
