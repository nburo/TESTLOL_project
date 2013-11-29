using UnityEngine;
using System.Collections;

public class ShadowScale : MonoBehaviour {

	public float scaleFactor = 1;
	public float YZ_Factor = 4;

	private Vector3 RayDirection;
	private RaycastHit hitInfo;

	private Vector3 DefaultScale;
	private Vector3 DefaultPosition;
	private Vector3 CurrentScale;
	private Vector3 CurrentPosition;

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

		transform.localScale = CurrentScale;
		transform.localPosition = CurrentPosition;

		/*****************************************
		 *****************************************/

	}
}
