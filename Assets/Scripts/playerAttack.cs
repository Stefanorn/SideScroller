using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	Animator anim;
	public float attackDelay = 0.5f;

	float attackDelayCatcher;
	// Use this for initialization
	void Start () {
		attackDelayCatcher = attackDelay;
		attackDelay = 0f;
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		attackDelay -= Time.deltaTime;
		if(Input.GetAxis("Fire1") > 0 && attackDelay < 0f){
			anim.SetBool("Attack", true);
			attackDelay  = attackDelayCatcher;
		}
		else{
			anim.SetBool("Attack", false);
		}
	
	}
}
