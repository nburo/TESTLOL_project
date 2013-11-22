/*
 * Basic movement Handling
 * The goal is to have a common movement Motor for any object.
 * 
 * */

using UnityEngine;
using System.Collections;

public class MovementMotor : MonoBehaviour {

	// Default acceleration close to instantaneous
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

	void Update () {

		if (Jump && grounded) {
			if(grounded) {Z_Speed = Z_MaxSpeed;}
			grounded = false;
		}
		Jump = false;
		YZ_Last_Displacement = YZ_New_Displacement;

		// Compute X-Axis Movement
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

		// Compute Y-Axis Movement
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

		YZ_New_Displacement = -transform.position.z * YZ_Factor;

		// Compute Z-Axis Movement
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


		// Write the result
		Vector3 CurrentPosition = transform.position;
		CurrentPosition.x += X_Speed * Time.deltaTime;
		CurrentPosition.y += Y_Speed * Time.deltaTime - YZ_Last_Displacement + YZ_New_Displacement;


		//Temporary: collision Set to zero plane only
		if (CurrentPosition.z + Z_Speed * Time.deltaTime < 0) {
			CurrentPosition.z += Z_Speed * Time.deltaTime;
		} else {
			CurrentPosition.z = 0;
			grounded=true;
		}


		transform.position = CurrentPosition;
		//Y position will acuumulate an error as-is because when jumping we SET 
		//the position to a value if it exceeds the maximum
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
	}


}
