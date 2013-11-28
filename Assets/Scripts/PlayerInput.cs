using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovementMotor))]

public class PlayerInput : MonoBehaviour {

	public float PlayerSpeed = 10.0f;
	public float JumpSpeed = 10.0f;

	MovementMotor Motor;

	private bool moveLeftKey;
	private bool moveRightKey;
	private bool moveUpKey;
	private bool moveDownKey;
	private bool jumpKey;
	private float PlayerSpeed_Diagonal;



	void Update () {

		//Read player inputs
		/*****************************************
		 *****************************************/
		moveLeftKey = Input.GetKey(KeyCode.LeftArrow);
		moveRightKey = Input.GetKey(KeyCode.RightArrow);
		moveUpKey = Input.GetKey(KeyCode.UpArrow);
		moveDownKey = Input.GetKey(KeyCode.DownArrow);
		jumpKey = Input.GetKey(KeyCode.Space);
		/*****************************************
		 *****************************************/

		Motor = this.transform.GetComponent<MovementMotor>();
		PlayerSpeed_Diagonal = PlayerSpeed / 1.41421356f;

		//Movement control for 8 directions
		//When two opposite keys are pressed at the same time, the player stops
		//its movement in this axis
		/*****************************************
		 *****************************************/
		if (moveLeftKey && !moveRightKey) {

			if (moveDownKey && !moveUpKey){         // Down-Left

				Motor.X_MaxSpeed = -PlayerSpeed_Diagonal;
				Motor.Y_MaxSpeed = -PlayerSpeed_Diagonal;

			}
			else if (moveUpKey && !moveDownKey){     // Up-Left

				Motor.X_MaxSpeed = -PlayerSpeed_Diagonal;
				Motor.Y_MaxSpeed =  PlayerSpeed_Diagonal;

			}
			else {                                         // Left

				Motor.X_MaxSpeed = -PlayerSpeed;
				Motor.Y_MaxSpeed =  0;

			}

		}
		else if (moveRightKey && !moveLeftKey){        

			if (moveDownKey && !moveUpKey){         // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed_Diagonal;
				Motor.Y_MaxSpeed = -PlayerSpeed_Diagonal;

			}
			else if (moveUpKey && !moveDownKey){     // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed_Diagonal;
				Motor.Y_MaxSpeed =  PlayerSpeed_Diagonal;

			}
			else{                                          // Rigth

				Motor.X_MaxSpeed =  PlayerSpeed;
				Motor.Y_MaxSpeed =  0;

			}
		}
		else{

			if (moveDownKey && !moveUpKey){         // Down
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed = -PlayerSpeed;
				
			}
			else if (moveUpKey && !moveDownKey){     // Up
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  PlayerSpeed;
				
			}
			else{                                          // Middle
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  0;
				
			}

		}
		/*****************************************
		 *****************************************/


		//Jump Handling
		/*****************************************
		 *****************************************/
		if (jumpKey){
			
			Motor.Jump = true;
			Motor.Z_MaxSpeed = -JumpSpeed;
			
		}
		/*****************************************
		 *****************************************/
	}
}
