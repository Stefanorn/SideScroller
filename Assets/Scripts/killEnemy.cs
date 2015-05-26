using UnityEngine;
using System.Collections;

public class killEnemy : MonoBehaviour {

	public float skopp = 2f;

	void OnTriggerEnter2D (Collider2D col) {

		if(col.tag == "Player") {
			GameObject parentObj = gameObject.transform.parent.gameObject;
			Destroy(parentObj , 2f);
			parentObj.GetComponent<walkForward>().enabled = false;
			if( parentObj.GetComponent<CircleCollider2D>() != null ){
				parentObj.GetComponent<CircleCollider2D>().enabled = false;
			}
			if(parentObj.GetComponent<PolygonCollider2D>() != null){
				parentObj.GetComponent<PolygonCollider2D>().enabled = false;
			}
			parentObj.GetComponent<Rigidbody2D>().AddForce( new Vector2 (0, 60f ));
			parentObj.transform.localScale = new Vector3(1,0.5f,1);

			col.GetComponent<Rigidbody2D>().velocity = new Vector3(0 , skopp) ;
		}

	}
}
