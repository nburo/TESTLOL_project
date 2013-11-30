using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour 
{
	public bool Collision_Up = false;
	public bool Collision_Down = false;
	public bool Collision_Left = false;
	public bool Collision_Right = false;
	public bool Collision_Over = false;
	public bool Collision_Below = false;
	


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "staticObjects") 
		{
			Vector3 currentPos = this.transform.position;
			Vector3 closestStaticBoundPoint = col.ClosestPointOnBounds(currentPos);
			Vector3 maxBound = this.collider.bounds.max;
			Vector3 minBound = this.collider.bounds.min;
			Vector3 maxDiff = maxBound - closestStaticBoundPoint;
			Vector3 minDiff = minBound - closestStaticBoundPoint;

			Collision_Right = (maxDiff.x >= 0 && 
			                   Mathf.Abs(maxDiff.x) <= Mathf.Abs(minDiff.x) && 
			                   Mathf.Abs(maxDiff.x) <= Mathf.Abs(maxDiff.y) && 
			                   Mathf.Abs(maxDiff.x) <= Mathf.Abs(minDiff.y));
			Collision_Left = (minDiff.x <= 0 && 
			                  Mathf.Abs(minDiff.x) <= Mathf.Abs(maxDiff.x) && 
			                  Mathf.Abs(minDiff.x) <= Mathf.Abs(minDiff.y) &&
			                  Mathf.Abs(minDiff.x) <= Mathf.Abs(maxDiff.y));
			Collision_Up = (maxDiff.y >= 0 && 
			                   Mathf.Abs(maxDiff.y) <= Mathf.Abs(minDiff.x) && 
			                   Mathf.Abs(maxDiff.y) <= Mathf.Abs(maxDiff.x) && 
			                   Mathf.Abs(maxDiff.y) <= Mathf.Abs(minDiff.y));
			Collision_Down = (minDiff.y <= 0 && 
			                Mathf.Abs(minDiff.y) <= Mathf.Abs(minDiff.x) && 
			                Mathf.Abs(minDiff.y) <= Mathf.Abs(maxDiff.x) && 
			                Mathf.Abs(minDiff.y) <= Mathf.Abs(maxDiff.y));

			Debug.Log ("left:"+Collision_Left+" right:"+Collision_Right+" up:"+Collision_Up+" down:"+Collision_Down);
		}
		else if (col.gameObject.tag == "dynamicObjects")
		{
			Debug.Log ("Enter dynamic trigger");
		}
	}

	void OnTriggerExit(Collider col)
	{
		Collision_Up = false;
		Collision_Down = false;
		Collision_Left = false;
		Collision_Right = false;
		Collision_Over = false;
		Collision_Below = false;
		Debug.Log ("collision exit");
	}
}
