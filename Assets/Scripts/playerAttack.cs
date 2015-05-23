using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetAxis("Fire1") > 0 ){
			anim.SetBool("Attack", true);
		}
		else{
			anim.SetBool("Attack", false);
		}
	
	}
}
