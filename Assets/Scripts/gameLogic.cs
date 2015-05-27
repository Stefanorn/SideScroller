using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLogic : MonoBehaviour {

	public GameObject player;
	public int lives = 4;

	public Text scoreTextUI;
	public Text LivesUI;

	public bool ignoreDeath = false;

	float totalPoints = 0f;
	GameObject playerInstace;
	
	// Use this for initialization
	void Start () {
		if(lives != 0){
			playerInstace = (GameObject)Instantiate( player, transform.position, Quaternion.identity);

			lives--;
			Lives ();
		}
		else {
			LoseGame();
		}
	}

	public Transform SendPlayerTransformInfo() {
			return playerInstace.transform;
	}
	void Update(){
		if(Input.GetKey(KeyCode.R)){
			GameObject PlayerRespawn = GameObject.FindGameObjectWithTag("Player");
			PlayerRespawn.transform.position = transform.position;
		}
	}
	public void Respawn(){

		if(ignoreDeath == true){
			return;
		}
		Invoke("WaitASecoindForRespawn",2);
	}
	void WaitASecoindForRespawn(){
		GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemys){
			Destroy(enemy);
		}
		if(lives != 0){
			playerInstace = (GameObject)Instantiate( player, transform.position, Quaternion.identity);
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