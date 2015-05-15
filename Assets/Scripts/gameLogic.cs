using UnityEngine;
using System.Collections;

public class gameLogic : MonoBehaviour {

	public GameObject player;
	public int lives = 4;
	
	// Use this for initialization
	void Start () {
		if(lives != 0){
			Instantiate( player, transform.position, Quaternion.identity);
		}
	}
	public void Respawn(){
		if(lives != 0){
			Instantiate( player, transform.position, Quaternion.identity);

			lives--;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
}
