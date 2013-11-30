using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


	public Transform cameraTarget;

	public float relative_X_Position = 0;
	public float relative_Y_Position = 0;
	public float relative_Z_Position = -100;

	private Vector3 CameraPosition;



	void Start () {
		// Intitialise Position
		/*****************************************
		 *****************************************/
		CameraPosition = new Vector3 (cameraTarget.position.x+relative_X_Position,cameraTarget.position.y+relative_Y_Position,relative_Z_Position);
		/*****************************************
		 *****************************************/
	}
	

	void LateUpdate () {

		//Update Camera Position Only if the target moved
		/*****************************************
		 *****************************************/
		if (cameraTarget.hasChanged) {
			CameraPosition.x = cameraTarget.position.x + relative_X_Position;
			CameraPosition.y = cameraTarget.position.y + relative_Y_Position;

			transform.position = CameraPosition;
		}
		/*****************************************
		 *****************************************/
	}
}
