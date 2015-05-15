using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	public Text lifeFX;

	int life;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate (){
		life = GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().lives; //TODO Optimize
		lifeFX.text = life.ToString();
	}
}
