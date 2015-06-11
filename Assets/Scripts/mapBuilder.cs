using UnityEngine;
using System.Collections;

[System.Serializable]
public class groundTypes{
	public string name;
	public GameObject singleBlock;
	public GameObject middleBlock;
	public GameObject rightCorner;
	public GameObject leftCorner;
	public GameObject centerBlock;
}


[ExecuteInEditMode]
public class mapBuilder : MonoBehaviour {

	public groundTypes[] ground;

	[Range (0, 4)]
	public int groundPicker = 0;

	[Range (1,30)]
	public  int lenght = 3;
	[Range (0,30)]
	public int leftWall = 0;
	[Range (0,30)]
	public int rightWall = 0;

	int offset = 0;
	int groundPickerUpdater = 0;

	void Update() {
        int blockSum = lenght + leftWall + rightWall;

        transform.position = new Vector3( (int)transform.position.x,
		                                  (int)transform.position.y,
		                                  (int)transform.position.z );

		if(groundPicker > ground.Length){ //Watches that you dont get a out of arry index error
			groundPicker = 0;
		}
		if(gameObject.transform.childCount != blockSum || groundPicker != groundPickerUpdater){ //Destroys all GameObject if the Legngth is changed
			if(groundPicker != groundPickerUpdater ){ //Adds and removes compoments and changes setting foreach platform
				DefaultState();                       //Reset everything to default
                if (groundPicker == 1){ //One Sided platform
					gameObject.GetComponent<BoxCollider2D>().usedByEffector = true;
					gameObject.AddComponent<PlatformEffector2D>();
				}
				else if( groundPicker == 2 ){ //Snow Platform
					gameObject.GetComponent<BoxCollider2D>().usedByEffector = true;
					gameObject.AddComponent<SurfaceEffector2D>();
					gameObject.tag = "SnowGround";
				}
				else if(groundPicker == 3){ //Sand Platform
					gameObject.GetComponent<BoxCollider2D>().usedByEffector = true;
					gameObject.AddComponent<SurfaceEffector2D>().forceScale = 0.7f;
					gameObject.GetComponent<SurfaceEffector2D>().speed = 0f;
				}
				else if(groundPicker == 4){ //SpacePlatform Parhaps need to optimize
					gameObject.GetComponent<BoxCollider2D>().enabled = false;
				}
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
		while(gameObject.transform.childCount != blockSum || groundPicker != groundPickerUpdater){ //Innstanciates the game objects if the lenght is changed
            
			groundPickerUpdater = groundPicker;
			if(lenght == 1 && rightWall == 0 && leftWall == 0){   //Calls for instaciate when this is only a single block
				InstaciateGroundType( ground[groundPicker].singleBlock );
			}
			else { // calls for a instaciate when the are speccial cases
                if (offset == 0 && leftWall == 0) 
                {
                    InstaciateGroundType(ground[groundPicker].leftCorner);
                }
                else if (offset == (lenght - 1) && rightWall == 0)
                {
                    InstaciateGroundType(ground[groundPicker].rightCorner);
                }
                else if (rightWall >= 1 && offset == (lenght - 1)) 
                {

                    InstaciateGroundType(ground[groundPicker].centerBlock);
                }
                else if (leftWall >= 1 && offset == 0)
                {
                    InstaciateGroundType(ground[groundPicker].centerBlock);
                }
                else if (offset > lenght) { 
                    InstaciateGroundType(ground[groundPicker].centerBlock);
                }
                else
                {
                    InstaciateGroundType(ground[groundPicker].middleBlock);
                }

			}

		}
	}
	void DefaultState(){
		if(gameObject.GetComponent<SurfaceEffector2D>()){
			DestroyImmediate(gameObject.GetComponent<SurfaceEffector2D>());
		}
		if(gameObject.GetComponent<PlatformEffector2D>()){
			DestroyImmediate(gameObject.GetComponent<PlatformEffector2D>());
		}
		gameObject.GetComponent<BoxCollider2D>().usedByEffector = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;

		gameObject.tag = "Untagged";
		
	}
	void InstaciateGroundType( GameObject groundTrans){ //Takes in the right GameObject and instanciates it to the right place
		int wallOffset = 0;
        if (offset < lenght)
        {
            Vector3 platformPos = new Vector3(transform.position.x + (float)offset, //Finds the right place
                                                transform.position.y,
                                                transform.position.z);

            GameObject instaceOfGround = (GameObject)Instantiate(groundTrans,
                                                                  platformPos,
                                                                  Quaternion.identity);
            instaceOfGround.transform.SetParent(gameObject.transform);
        }
        while (offset == 0  && leftWall != wallOffset ){
			Vector3 wallPos = new Vector3(	transform.position.x + offset, //Finds the right place
			                                transform.position.y + wallOffset +1,
			                                transform.position.z);
			GameObject instaceOfWall = (GameObject)Instantiate(   groundTrans, 
			                                                      wallPos,
			                                                      Quaternion.identity );
			instaceOfWall.transform.SetParent(gameObject.transform); 
			wallOffset++;
		}
        if(offset > lenght)
        {
           Vector3 wallPos = new Vector3(	transform.position.x + lenght-1, //Finds the right place
			                                transform.position.y + (offset - lenght ),
			                                transform.position.z);
			GameObject instaceOfWall = (GameObject)Instantiate(   groundTrans, 
			                                                      wallPos,
			                                                      Quaternion.identity );
            instaceOfWall.transform.SetParent(gameObject.transform);
        }
        //Debug.Log((lenght + rightWall) + " " + (offset + 1) );
        offset++;
	}
}
