using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLogic : MonoBehaviour {

	public GameObject player;
	public int lives = 4;

	public Text scoreTextUI;
	public Text LivesUI;

	float totalPoints = 0f;
	
	// Use this for initialization
	void Start () {
		Respawn();
	}
	public void Respawn(){
		if(lives != 0){
			Instantiate( player, transform.position, Quaternion.identity);
			lives--;
			Lives ();
		}
		else {
			LoseGame();
		}
	}
	public void Score(float point ) {
		totalPoints += point;
		scoreTextUI.text = "Points : " + totalPoints.ToString();

		//hvítur 10 grænn 20 rauður 50 , blár 100 og svartur 500
	}
	void Lives () {
		LivesUI.text = "Lives : " + lives;
	}
	public void WinGame() {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void LoseGame() {
		Application.LoadLevel(Application.loadedLevel);
	}
}