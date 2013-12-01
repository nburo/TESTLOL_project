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
	public bool Collision_Below = false;



	void OnTriggerEnter(Collider col)
	{
		Vector3 currentPos = this.transform.position; //currect moving object position
		Vector3 closestColBoundPoint = col.ClosestPointOnBounds (currentPos); //closest point on bound of the collided object
		Vector3 maxBound = this.collider.bounds.max; // positive-most corner of the moving object
		Vector3 minBound = this.collider.bounds.min; // negative-most corner of the moving object
		Vector3 maxDiff = maxBound - closestColBoundPoint; //difference between positive-most corner and closest point on bound
		Vector3 minDiff = minBound - closestColBoundPoint; //difference between negative-most corner and closest point on bound

		if (col.gameObject.tag == "floor") 
			{
				if(maxDiff.z >= 0)
					Collision_Below = true;
			}



		if (col.gameObject.tag == "staticObjects" || col.gameObject.tag == "dynamicObjects") { //if colliding static (non-movable objects)


			//for example, let's explain Collision_Right. The Right side of an object is a positive side (meaning it has a positive x coordinate
			//relative to its center). In order for Collision_Right to be true :
			//maxDiff.x most be >=0 (if the moving object gets inside the static object by jumping) so we know we are at least on the right side
			//to know that we are indeed on the right (and nothing else), we must verify that |maxDiff.x| has indeed be the smallest value
			/*Collision_Right = (	Mathf.Abs (maxDiff.x) <= Mathf.Abs (maxDiff.y) && 
								Mathf.Abs (maxDiff.x) <= Mathf.Abs (minDiff.y));
			Collision_Left = (	Mathf.Abs (minDiff.x) <= Mathf.Abs (minDiff.y) &&
								Mathf.Abs (minDiff.x) <= Mathf.Abs (maxDiff.y));
			Collision_Up = (	Mathf.Abs (maxDiff.y) <= Mathf.Abs (minDiff.x) && 
								Mathf.Abs (maxDiff.y) <= Mathf.Abs (maxDiff.x));
			Collision_Down = (	Mathf.Abs (minDiff.y) <= Mathf.Abs (minDiff.x) && 
								Mathf.Abs (minDiff.y) <= Mathf.Abs (maxDiff.x));
			Collision_Below = (maxDiff.z >= 0);*/

			if(Mathf.Abs (maxDiff.x) <= Mathf.Abs (maxDiff.y) && 
			   Mathf.Abs (maxDiff.x) <= Mathf.Abs (minDiff.y))
				Collision_Right = true;
			if(Mathf.Abs (minDiff.x) <= Mathf.Abs (minDiff.y) &&
			   Mathf.Abs (minDiff.x) <= Mathf.Abs (maxDiff.y))
				Collision_Left = true;
			if(Mathf.Abs (maxDiff.y) <= Mathf.Abs (minDiff.x) && 
			   Mathf.Abs (maxDiff.y) <= Mathf.Abs (maxDiff.x))
				Collision_Up = true;
			if(Mathf.Abs (minDiff.y) <= Mathf.Abs (minDiff.x) && 
			   Mathf.Abs (minDiff.y) <= Mathf.Abs (maxDiff.x))
				Collision_Down = true;
			if(maxDiff.z >= 0)
				Collision_Below = true;

			//below and over are not done yet

			Debug.Log ("left:" + Collision_Left + " right:" + Collision_Right + " up:" + Collision_Up + " down:" + Collision_Down + minDiff.z);
		
		} 
		else if (col.gameObject.tag == "otherObjects") 
		{ //if colliding dynamic (movable) objects
			Debug.Log ("Enter dynamic trigger");
		} 


	}


	void OnTriggerExit(Collider col) //upon exiting the collision status
	{
		Vector3 currentPos = this.transform.position; //currect moving object position
		Vector3 closestColBoundPoint = col.ClosestPointOnBounds (currentPos); //closest point on bound of the collided object
		Vector3 maxBound = this.collider.bounds.max; // positive-most corner of the moving object
		Vector3 minBound = this.collider.bounds.min; // negative-most corner of the moving object
		Vector3 maxDiff = maxBound - closestColBoundPoint; //difference between positive-most corner and closest point on bound
		Vector3 minDiff = minBound - closestColBoundPoint; //difference between negative-most corner and closest point on bound

	

		if(Mathf.Abs (maxDiff.x) <= Mathf.Abs (maxDiff.y) && 
		   Mathf.Abs (maxDiff.x) <= Mathf.Abs (minDiff.y))
			Collision_Right = false;
		if(Mathf.Abs (minDiff.x) <= Mathf.Abs (minDiff.y) &&
		   Mathf.Abs (minDiff.x) <= Mathf.Abs (maxDiff.y))
			Collision_Left = false;
		if(Mathf.Abs (maxDiff.y) <= Mathf.Abs (minDiff.x) && 
		   Mathf.Abs (maxDiff.y) <= Mathf.Abs (maxDiff.x))
			Collision_Up = false;
		if(Mathf.Abs (minDiff.y) <= Mathf.Abs (minDiff.x) && 
		   Mathf.Abs (minDiff.y) <= Mathf.Abs (maxDiff.x))
			Collision_Down = false;
		if(maxDiff.z <= 0)
			Collision_Below = false;
		//Debug.Log ("collision exit");
	}
	
}
