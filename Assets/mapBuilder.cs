using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class mapBuilder : MonoBehaviour {
	
	public GameObject[] groundType; 
	[Range (1,30)]
	public  int lenght = 3;

	int offset = 0;
	int arrayIndex = 0;

	void Update() {

		if(gameObject.transform.childCount != lenght){ //Destroys all GameObject if the Legngth is changed
			Transform[] childs;
			childs = GetComponentsInChildren<Transform>();
			foreach(Transform child in childs ){
				if(child != this.transform)
					DestroyImmediate(child.gameObject);
			}
			BoxCollider2D col = transform.GetComponent<BoxCollider2D>();         // Canges the size and offset of the boxcollider to corepresent the 
			col.offset = new Vector2( ((float)lenght/2f) - 0.5f , col.offset.y );// length of the platform
			col.size = new Vector2( (float)lenght , col.size.y );
		}
		offset = 0; //offsets the tiles 1 unit to the left and also helps with choosing of the tile image
		bool indexStateChecker = false;
		while(gameObject.transform.childCount != lenght){ //Innstanciates the game objects if the lenght is changed

			if(lenght == 1){
				arrayIndex = 0;
			}
			else{
				if(offset == 0){
					arrayIndex = 3;
				}
				else if(offset == (lenght-1)){
					arrayIndex = 2;
				}
				else {
					arrayIndex = 1;
				}
			}
			Vector3 platformPos = new Vector3(	transform.position.x + offset, 
			                                  transform.position.y,
			                                  transform.position.z);
			GameObject instaceOfGround = (GameObject)Instantiate( groundType[arrayIndex],
			                                                     platformPos,
			                                                     Quaternion.identity );
			instaceOfGround.transform.SetParent(gameObject.transform);
			offset++;
		}
	}

}
