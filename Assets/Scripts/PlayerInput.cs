using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovementMotor))]

public class PlayerInput : MonoBehaviour {

	public float PlayerSpeed = 10.0f;
	public float JumpSpeed = 10;

	MovementMotor Motor;



	void Update () {

		Motor = this.transform.GetComponent<MovementMotor>();

		//Movement control for 8 directions
		//When two opposite keys are pressed at the same time, the player stops
		//its movement in this axis
		if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {

			if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)){         // Down-Left

				Motor.X_MaxSpeed = -PlayerSpeed;
				Motor.Y_MaxSpeed = -PlayerSpeed;

			}
			else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){     // Up-Left

				Motor.X_MaxSpeed = -PlayerSpeed;
				Motor.Y_MaxSpeed =  PlayerSpeed;

			}
			else {                                         // Left

				Motor.X_MaxSpeed = -PlayerSpeed * 1.41421356f;
				Motor.Y_MaxSpeed =  0;

			}

		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){        

			if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)){         // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed;
				Motor.Y_MaxSpeed = -PlayerSpeed;

			}
			else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){     // Down-Right

				Motor.X_MaxSpeed =  PlayerSpeed;
				Motor.Y_MaxSpeed =  PlayerSpeed;

			}
			else{                                          // Rigth

				Motor.X_MaxSpeed =  PlayerSpeed * 1.41421356f;
				Motor.Y_MaxSpeed =  0;

			}
		}
		else{

			if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)){         // Down
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed = -PlayerSpeed * 1.41421356f;
				
			}
			else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){     // Up
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  PlayerSpeed * 1.41421356f;
				
			}
			else{                                          // Middle
				
				Motor.X_MaxSpeed =  0;
				Motor.Y_MaxSpeed =  0;
				
			}

		}

		//Jump
		if (Input.GetKey(KeyCode.Space)){
			
			Motor.Jump = true;
			Motor.Z_MaxSpeed = -JumpSpeed;
			
		}
	}
}
