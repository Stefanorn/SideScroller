using UnityEngine;
using System.Collections;

public class sawbladeWithNotes : MonoBehaviour {

	public Transform[] notes;
	public Transform sawGO;
	public float timeMultyplayer = 0.2f;


	int notePicker = 0;
	int nopePicker2 = 1;
	float timer = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += ( Time.deltaTime * timeMultyplayer ) /  Vector3.Distance( notes[notePicker].position , notes[nopePicker2].position );
		sawGO.position = Vector3.Lerp( notes[notePicker].position , notes[nopePicker2].position, timer );

		if(timer >= 1f){ // Resets times and increses the notepicker and takes care of whene notepicker 
			timer = 0f;	//  is greater than the arry 
			nopePicker2++;
			notePicker++;
			if(notePicker >= notes.Length){
				notePicker = 0;
			}
			else if( nopePicker2 >= notes.Length ){
				nopePicker2 = 0;
			}
		}

	}
}
