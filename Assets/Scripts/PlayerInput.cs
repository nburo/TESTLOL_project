using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovementMotor))]

public class PlayerInput : MonoBehaviour {

	public float PlayerSpeed = 10.0f;
	public float JumpSpeed = 10;

	MovementMotor Motor;



	void Update () {

		bool moveLeftKey = Input.GetKey(KeyCode.LeftArrow);
		bool moveRightKey = Input.GetKey(KeyCode.RightArrow);
		bool moveUpKey = Input.GetKey(KeyCode.UpArrow);
		bool moveDownKey = Input.GetKey(KeyCode.DownArrow);
		bool jumpKey = Input.GetKey(KeyCode.Space);

		Motor = this.transform.GetComponent<MovementMotor>();

		//Movement control for 8 directions
		//When two opposite keys are pressed at the same time, the player stops
		//its movement in this axis
		if (moveLeftKey && !moveRightKey) {

			if (moveDownKey && !moveUpKey){         // Down-Left

				Motor.X_MaxSpeed = -PlayerSpeed;
				Motor.Y_MaxSpeed = -PlayerSpeed;

			}
			else if (moveUpKey && !moveDownKey){     // Up-Left

				Motor.X_MaxSpeed = -PlayerSpeed;
				Motor.Y_MaxSpeed =  PlayerSpeed;

			}
			else {                                         // Left

				Motor.X_MaxSpeed = -PlayerSpeed * 1.41421356f;
				Motor.Y_MaxSpeed =  0;

			}

		}
		else if (moveRightKey && !moveLeftKey){        

			if (moveDownKey && !moveUpKey){         // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed;
				Motor.Y_MaxSpeed = -PlayerSpeed;

			}
			else if (moveUpKey && !moveDownKey){     // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed;
				Motor.Y_MaxSpeed =  PlayerSpeed;

			}
			else{                                          // Rigth

				Motor.X_MaxSpeed =  PlayerSpeed * 1.41421356f;
				Motor.Y_MaxSpeed =  0;

			}
		}
		else{

			if (moveDownKey && !moveUpKey){         // Down
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed = -PlayerSpeed * 1.41421356f;
				
			}
			else if (moveUpKey && !moveDownKey){     // Up
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  PlayerSpeed * 1.41421356f;
				
			}
			else{                                          // Middle
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  0;
				
			}

		}

		//Jump
		if (jumpKey){
			
			Motor.Jump = true;
			Motor.Z_MaxSpeed = -JumpSpeed;
			
		}
	}
}
