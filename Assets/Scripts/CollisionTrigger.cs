using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour 
{
	//public bools to determine which side is being collided (from the moving object perpective)
	public bool Collision_Up = false;
	public bool Collision_Down = false;
	public bool Collision_Left = false;
	public bool Collision_Right = false;
	public bool Collision_Over = false;
	public bool Collision_Below = true;



	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "staticObjects") //if colliding static (non-movable objects)
		{
			Vector3 currentPos = this.transform.position; //currect moving object position
			Vector3 closestStaticBoundPoint = col.ClosestPointOnBounds(currentPos); //closest point on bound of the static object
			Vector3 maxBound = this.collider.bounds.max; // positive-most corner of the moving object
			Vector3 minBound = this.collider.bounds.min; // negative-most corner of the moving object
			Vector3 maxDiff = maxBound - closestStaticBoundPoint; //difference between positive-most corner and closest point on bound
			Vector3 minDiff = minBound - closestStaticBoundPoint; //difference between negative-most corner and closest point on bound

			//for example, let's explain Collision_Right. The Right side of an object is a positive side (meaning it has a positive x coordinate
			//relative to its center). In order for Collision_Right to be true :
			//maxDiff.x most be >=0 (if the moving object gets inside the static object by jumping) so we know we are at least on the right side
			//to know that we are indeed on the right (and nothing else), we must verify that |maxDiff.x| has indeed be the smallest value
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

			//below and over are not done yet

			Debug.Log ("left:"+Collision_Left+" right:"+Collision_Right+" up:"+Collision_Up+" down:"+Collision_Down);
		}
		else if (col.gameObject.tag == "dynamicObjects") //if colliding dynamic (movable) objects
		{
			Debug.Log ("Enter dynamic trigger");
		}
	}
	
	void OnTriggerExit(Collider col) //upon exiting the collision status
	{
		Collision_Up = false; //we set all Collision triggers to false
		Collision_Down = false;
		Collision_Left = false;
		Collision_Right = false;
		Collision_Over = false;
		Collision_Below = true; //except below (need to work on this one)
		Debug.Log ("collision exit");
	}
}
