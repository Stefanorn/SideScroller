﻿using UnityEngine;
using System.Collections;

public class cleanUp : MonoBehaviour {

	void OnTriggerEnter2D (){

		Destroy(gameObject);
	}
}