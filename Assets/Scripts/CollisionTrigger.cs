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
	

	private System.Collections.Generic.Dictionary<int,char> collisionSides = new System.Collections.Generic.Dictionary<int, char>();

	void OnTriggerEnter(Collider col)
	{

		char side = StaticTools.CollisionDectection(this.gameObject.collider.bounds,col.bounds);

		collisionSides.Add (col.GetInstanceID(), side);

		if (col.gameObject.tag == "floor") 
			{
			//	if(maxDiff.z >= 0)
					Collision_Below = true;
			}

		if (col.gameObject.tag == "staticObjects" || col.gameObject.tag == "dynamicObjects") { //if colliding static (non-movable objects)

			//this method return the char of the side being collided by this.gameObject


			//using if's instead of Collision_Right = side == 'r' so collision bools don't reset on new trigger enters.
			if(side == 'r')
				Collision_Right = true;
			if(side == 'l')
				Collision_Left = true;
			if(side == 'u')
				Collision_Up = true;
			if(side == 'd')
				Collision_Down = true;

			//below and over are not done yet

			Debug.Log ("left:" + Collision_Left + " right:" + Collision_Right + " up:" + Collision_Up + " down:" + Collision_Down);
		
		} 
		else if (col.gameObject.tag == "otherObjects") 
		{ //if colliding other kinds of objects
			Debug.Log ("Enter (other) trigger");
		} 


	}


	void OnTriggerExit(Collider col) //upon exiting the collision status
	{
		char side;

		collisionSides.TryGetValue (col.GetInstanceID (), out side);

		collisionSides.Remove (col.GetInstanceID ());

		if(side == 'r')
			Collision_Right = false;
		if(side == 'l')
			Collision_Left = false;
		if(side == 'u')
			Collision_Up = false;
		if(side == 'd')
			Collision_Down = false;

		if (col.gameObject.tag == "floor") 
		{
			//	if(maxDiff.z >= 0)
			Collision_Below = false;
		}

		//Debug.Log ("collision exit");
	}
	
}
