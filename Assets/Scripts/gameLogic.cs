using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLogic : MonoBehaviour {

	public GameObject player;
	public int lives = 4;

	public Text scoreTextUI;

	float totalPoints = 0f;
	
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
	public void Score(float point ) {
		totalPoints += point;
		scoreTextUI.text = totalPoints.ToString();

		//hvítur 10 grænn 20 rauður 50 , blár 100 og svartur 500
	}
	

}