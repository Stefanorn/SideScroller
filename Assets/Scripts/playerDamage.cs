using UnityEngine;
using System.Collections;

public class playerDamage : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Enemy"){


			col.GetComponent<Rigidbody2D>().AddForce(	new Vector2( 0, 6f ),
			                                            ForceMode2D.Impulse );
			Destroy(col);
		}
	
	}
}
