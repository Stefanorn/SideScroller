﻿using UnityEngine;
using System.Collections;

public class winSenario : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {

		if(col.tag == "Player"){
			GameObject.FindWithTag("Respawn").GetComponent<gameLogic>().WinGame();
		}

	}
}
