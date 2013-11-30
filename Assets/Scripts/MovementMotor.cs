/*
 * Basic movement Handling
 * The goal is to have a common movement Motor for any object.
 * 
 * */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CollisionTrigger))]

public class MovementMotor : MonoBehaviour {

	public float X_Accel    = 1000000;
	public float Y_Accel    = 1000000;
	public float Z_Accel    = -30; //(Gravity)

	public float X_MaxSpeed = 0;
	public float Y_MaxSpeed = 0;
	public float Z_MaxSpeed = 0;

	public bool Jump;
	public float YZ_Factor;


	private float X_Speed = 0;
	private float Y_Speed = 0;
	private float Z_Speed = 0;
	
	private bool grounded = true;
	private float YZ_Last_Displacement = 0;
	private float YZ_New_Displacement = 0;

	private CollisionTrigger Collision;

	void Update () {

		// Check if there are new collisions every frame the GameObject moves
		/*****************************************
		 *****************************************/
		if (transform.hasChanged) {
			Collision = this.transform.GetComponent<CollisionTrigger>();
		}

		// Set HasChanged to false for functions that will not 
		// execute when the object does not move
		/*****************************************
		 *****************************************/
		transform.hasChanged = false;
		/*****************************************
		 *****************************************/

		// Jump Handling
		/*****************************************
		 *****************************************/
		if (Jump && grounded) {
			Z_Speed = Z_MaxSpeed;
			grounded = false;
		}
		Jump = false;
		YZ_Last_Displacement = YZ_New_Displacement;
		/*****************************************
		 *****************************************/


		// X-Axis Movement
		/*****************************************
		 *****************************************/
		if (X_MaxSpeed < 0) {

				if ((X_Speed - X_Accel * Time.deltaTime) <= X_MaxSpeed) {
					X_Speed = X_MaxSpeed;
				} else {
					X_Speed -= X_Accel * Time.deltaTime;
				}

		} else if (X_MaxSpeed > 0){

				if ((X_Speed + X_Accel * Time.deltaTime) >= X_MaxSpeed) {
					X_Speed = X_MaxSpeed;
				} else {
					X_Speed += X_Accel * Time.deltaTime;

				}

		} else { // Decelerate
			X_Speed = 0;
		}
		//Handle Collision
		if (X_Speed > 0 && Collision.Collision_Right) {// Prevent Right movement
			X_Speed = 0;
		}
		if(X_Speed < 0 && Collision.Collision_Left){// Prevent Left movement
			X_Speed = 0;
			grounded = true;
		}

		/*****************************************
		 *****************************************/

		// Y-Axis Movement
		/*****************************************
		 *****************************************/
		if (Y_MaxSpeed < 0) {

				if ((Y_Speed - Y_Accel * Time.deltaTime) <= Y_MaxSpeed) {
					Y_Speed = Y_MaxSpeed;
				} else {
					Y_Speed -= Y_Accel * Time.deltaTime;
				}

		} else if (Y_MaxSpeed > 0) {

				if ((Y_Speed + Y_Accel * Time.deltaTime) >= Y_MaxSpeed) {
					Y_Speed = Y_MaxSpeed;
				} else {
					Y_Speed += Y_Accel * Time.deltaTime;
				}

		} else { // Decelerate
			Y_Speed = 0;
		}

		//Handle Collision
		if (Y_Speed > 0 && Collision.Collision_Up) {// Prevent Up movement
			Y_Speed = 0;
		}
		if(Y_Speed < 0 && Collision.Collision_Down){// Prevent Down movement
			Y_Speed = 0;
		}

		YZ_New_Displacement = -transform.position.z * YZ_Factor;
		/*****************************************
		 *****************************************/

		// Z-Axis Movement
		/*****************************************
		 *****************************************/
		if (Z_MaxSpeed < 0) {

			if ((Z_Speed - Z_Accel * Time.deltaTime) <= Z_MaxSpeed) {
				Z_Speed = Z_MaxSpeed;
			} else {
				Z_Speed -= Z_Accel * Time.deltaTime;
			}

		} else if (Z_MaxSpeed > 0) {

			if ((Z_Speed + Z_Accel * Time.deltaTime) >= Z_MaxSpeed) {
				Z_Speed = Z_MaxSpeed;
			} else {
				Z_Speed += Z_Accel * Time.deltaTime;
			}

		} else { // Decelerate
			Z_Speed = 0;
		}


		//Handle Collision
		if (Z_Speed > 0 && Collision.Collision_Below) {// Prevent movement Below
			Z_Speed = 0;
			grounded = true;
		}
		if(Z_Speed < 0 && Collision.Collision_Over){// Prevent movement Over
			Z_Speed = 0;
		}
		/*****************************************
		 *****************************************/
		


		// Write the result
		/*****************************************
		 *****************************************/
		Vector3 CurrentPosition = transform.position;
		CurrentPosition.x += X_Speed * Time.deltaTime;
		CurrentPosition.y += Y_Speed * Time.deltaTime - YZ_Last_Displacement + YZ_New_Displacement;
		CurrentPosition.z += Z_Speed * Time.deltaTime;

		transform.position = CurrentPosition;

	}
		/*****************************************
		 *****************************************/



}
