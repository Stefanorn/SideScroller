using UnityEngine;
using System.Collections;

[System.Serializable]
public class groundTypes{
	public string name;
	public GameObject singleBlock;
	public GameObject middleBlock;
	public GameObject rightCorner;
	public GameObject leftCorner;
}


[ExecuteInEditMode]
public class mapBuilder : MonoBehaviour {

	public groundTypes[] ground;

	[Range (0, 3)]
	public int groundPicker = 0;
	int groundPickerUpdater = 0;
	[Range (1,30)]
	public  int lenght = 3;

	int offset = 0;

	void Update() {
		if(groundPicker > ground.Length){ //Watches that you dont get a out of arry index error
			groundPicker = 0;
		}

		if(gameObject.transform.childCount != lenght || groundPicker != groundPickerUpdater){ //Destroys all GameObject if the Legngth is changed
			if(groundPicker != groundPickerUpdater ){
				SetupTheGroundType();
			}
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
		while(gameObject.transform.childCount != lenght  || groundPicker != groundPickerUpdater){ //Innstanciates the game objects if the lenght is changed
			groundPickerUpdater = groundPicker;
			if(lenght == 1){ 
				InstaciateGroundType( ground[groundPicker].singleBlock );
			}
			else {
				if(offset == 0){
					InstaciateGroundType( ground[groundPicker].leftCorner );
				}
				else if(offset == (lenght-1)){
					InstaciateGroundType( ground[groundPicker].rightCorner );
				}
				else {
					InstaciateGroundType( ground[groundPicker].middleBlock);
				}
			}

		}
	}
	
	void InstaciateGroundType( GameObject groundTrans){ //Takes in the right GameObject and instanciates it to the right place

		Vector3 platformPos = new Vector3(	transform.position.x + (float)offset, //Finds the right place
		                                  transform.position.y,
		                                  transform.position.z);

		GameObject instaceOfGround = (GameObject)Instantiate( groundTrans, 
		                                                      platformPos,
		                                                      Quaternion.identity );
		instaceOfGround.transform.SetParent(gameObject.transform); 
		offset++;
	}
	void SetupTheGroundType(){
		switch(groundPicker){
			PlatformEffector2D pe = (PlatformEffector2D)gameObject.GetComponent<PlatformEffector2D>();
			SurfaceEffector2D se = (SurfaceEffector2D)gameObject.GetComponent<SurfaceEffector2D>();
			BoxCollider2D bc = (BoxCollider2D)gameObject.GetComponent<BoxCollider2D>();
			case 0:
				bc.usedByEffector = false;
				gameObject.tag = "Untagged";
				break;
			case 1:
//				gameObject.GetComponent<BoxCollider2D>().usedByEffector = true;
//				if(gameObject.GetComponent<SurfaceEffector2D>())
//					DestroyImmediate(gameObject.GetComponent<SurfaceEffector2D>());
//				gameObject.AddComponent<PlatformEffector2D>();
//				gameObject.tag = "Untagged";
				break;
			case 2:
//				gameObject.GetComponent<BoxCollider2D>().usedByEffector = false;
//				if(gameObject.GetComponent<PlatformEffector2D>())
//					DestroyImmediate(gameObject.GetComponent<PlatformEffector2D>());
//				if( gameObject.GetComponent<PlatformEffector2D>() = false)
//					SurfaceEffector2D se = (SurfaceEffector2D)gameObject.AddComponent<SurfaceEffector2D>();
//				se.speed = 10f;
//				se.forceScale = 0.1f;
//				se.useFriction = true;
//				se.useBounce = true;
//				gameObject.tag = "SnowGround";
				break;
			case 3:
//				gameObject.GetComponent<BoxCollider2D>().usedByEffector = true;
//				if(gameObject.GetComponent<PlatformEffector2D>())
//					DestroyImmediate(gameObject.GetComponent<PlatformEffector2D>());
//					SurfaceEffector2D se = (SurfaceEffector2D)gameObject.AddComponent<SurfaceEffector2D>();
//				se.speed = 0f;	
//				se.forceScale = 0.7f;
//				se.useFriction = true;
//				se.useBounce = true;
//				gameObject.tag = "Untagged";		
				break;
			default:
//				gameObject.GetComponent<BoxCollider2D>().usedByEffector = false;
//				
//				gameObject.tag = "Untagged";
				break;
		}



	}
}
