using UnityEngine;
using System.Collections;

public class ShadowScale : MonoBehaviour {

	public float scaleFactor = 1;
	public float YZ_Factor = 4;
	public float SmoothTime = 0.1f;

	private Vector3 RayDirection;
	private RaycastHit hitInfo;

	private Vector3 DefaultScale;
	private Vector3 DefaultPosition;
	private Vector3 CurrentScale;
	private Vector3 CurrentPosition;

	private Vector3 currentPositionVelocity;
	private Vector3 currentScaleVelocity;

	void Start () {
		// Intitialise Ray Downwards
		/*****************************************
		 *****************************************/
		RayDirection = new Vector3(0,0,1);
		/*****************************************
		 *****************************************/

		// Keep the initial parameters in memory
		/*****************************************
		 *****************************************/
		DefaultScale = transform.localScale;
		DefaultPosition = transform.localPosition;
		CurrentPosition = DefaultPosition;
		/*****************************************
		 *****************************************/
	}
	
	//Need to reduce the workload here
	void Update () {
		if(transform.parent.transform.hasChanged){

		// Find the nearest floor
		/*****************************************
		 *****************************************/
		Physics.Raycast(transform.parent.transform.position, RayDirection, out hitInfo);
		/*****************************************
		 *****************************************/

		// Scale and position the Shadow Accordingly
		/*****************************************
		 *****************************************/
		if (hitInfo.distance < 0.95 * scaleFactor) {
				CurrentScale = DefaultScale * (1 - hitInfo.distance / scaleFactor);
		} else {
			CurrentScale = DefaultScale * 0;
		}
		//CurrentPosition.z = DefaultPosition.z + hitInfo.distance;
		CurrentPosition.y = DefaultPosition.y - hitInfo.distance*YZ_Factor;

		//transform.localScale = CurrentScale;
		transform.localPosition = CurrentPosition;
		transform.localScale = Vector3.SmoothDamp(transform.localScale, CurrentScale, ref currentScaleVelocity, SmoothTime);
		/*****************************************
		 *****************************************/
		}
	}
}
