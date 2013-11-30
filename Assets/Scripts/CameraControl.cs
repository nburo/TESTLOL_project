using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


	public Transform cameraTarget;

	public float relative_X_Position = 0;
	public float relative_Y_Position = 0;
	public float relative_Z_Position = -100;

	public bool stillWithinBounds;

	public float X_Bound = 0;
	public float Y_Bound = 0;

	public bool cameraSmoothing;
	public float SmoothTime;

	private Vector3 CameraPosition;
	private Vector3 currentVelocity;




	void Start () {

		// Intitialise Position
		/*****************************************
		 *****************************************/
		CameraPosition = new Vector3 (cameraTarget.position.x+relative_X_Position,cameraTarget.position.y+relative_Y_Position,relative_Z_Position);
		currentVelocity = Vector3.zero;
		/*****************************************
		 *****************************************/

	}
	

	void LateUpdate () {

		//Compute new Camera position
		/*****************************************
		 *****************************************/
		if (cameraTarget.hasChanged) {// Compute only if the target transform changed

			if (stillWithinBounds){ // Allow the camera not to move if the Target Object is within given bounds

				if (transform.position.x + relative_X_Position > cameraTarget.position.x + X_Bound ){

					CameraPosition.x = cameraTarget.position.x + relative_X_Position + X_Bound;
				
				} else if (transform.position.x + relative_X_Position < cameraTarget.position.x - X_Bound){
				
					CameraPosition.x = cameraTarget.position.x + relative_X_Position - X_Bound;
				
				}

				if (transform.position.y + relative_Y_Position > cameraTarget.position.y + Y_Bound ){
				
					CameraPosition.y = cameraTarget.position.y + relative_Y_Position + Y_Bound;
				
				} else if (transform.position.y + relative_Y_Position < cameraTarget.position.y - Y_Bound){
				
					CameraPosition.y = cameraTarget.position.y + relative_Y_Position - Y_Bound;
				
				}

			} else {// Follow Every Single Target Object Movement

				CameraPosition.x = cameraTarget.position.x + relative_X_Position;
				CameraPosition.y = cameraTarget.position.y + relative_Y_Position;
			
			}
		}
		/*****************************************
		 *****************************************/

		//Write the camera position
		/*****************************************
		 *****************************************/
		if (cameraTarget.hasChanged || transform.hasChanged){// Compute only if a transform changed

			if(cameraSmoothing){ // Smooth Movement
				
				transform.hasChanged = false;
				transform.position = Vector3.SmoothDamp(transform.position, CameraPosition, ref currentVelocity, SmoothTime);

			} else { // No smoothing
			
				transform.position = CameraPosition;
			
			}
		}
	}
}
