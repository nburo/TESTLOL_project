using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovementMotor))]

public class PlayerInput : MonoBehaviour {

	public bool isActive = true;

	public float PlayerSpeed = 10.0f;
	public float JumpSpeed = 10;

	private bool moveLeftKey;
	private bool moveRightKey;
	private bool moveUpKey;
	private bool moveDownKey;
	private bool jumpKey;
	private bool gameMenuKey;
	private bool characterMenuKey;

	private MovementMotor Motor;
	private float PlayerSpeed_Diagonal; 

	private bool firstScan;

	void Start(){
		Motor = this.transform.GetComponent<MovementMotor> ();
		firstScan = true;
		}

	void Update () {

		if (isActive) {

			// Read Player Inputs
			/***********************************************
	 		**********************************************/
			if(!firstScan){
				moveLeftKey = Input.GetKey (KeyCode.LeftArrow);
				moveRightKey = Input.GetKey (KeyCode.RightArrow);
				moveUpKey = Input.GetKey (KeyCode.UpArrow);
				moveDownKey = Input.GetKey (KeyCode.DownArrow);
				jumpKey = Input.GetKey (KeyCode.Space);

				gameMenuKey = Input.GetKeyDown (KeyCode.Escape);
				characterMenuKey = Input.GetKeyDown (KeyCode.Return);
			}
			/***********************************************
		 	**********************************************/

			firstScan = false;

		} else {

			moveLeftKey = false;
			moveRightKey = false;
			moveUpKey = false;
			moveDownKey = false;
			jumpKey = false;
	
			gameMenuKey = false;
			characterMenuKey = false;

			firstScan = true;

		}

		//Movement control for 8 directions
		//When two opposite keys are pressed at the same time, the player stops
		//its movement in this axis
		/***********************************************
	 	**********************************************/
		//Motor = this.transform.GetComponent<MovementMotor> ();
		PlayerSpeed_Diagonal = PlayerSpeed / 1.41421356f;

		if (moveLeftKey && !moveRightKey) {

			if (moveDownKey && !moveUpKey) {         // Down-Left

					Motor.X_MaxSpeed = -PlayerSpeed_Diagonal;
					Motor.Y_MaxSpeed = -PlayerSpeed_Diagonal;

			} else if (moveUpKey && !moveDownKey) {     // Up-Left

					Motor.X_MaxSpeed = -PlayerSpeed_Diagonal;
					Motor.Y_MaxSpeed = PlayerSpeed_Diagonal;

			} else {                                         // Left

					Motor.X_MaxSpeed = -PlayerSpeed;
					Motor.Y_MaxSpeed = 0;

			}

		} else if (moveRightKey && !moveLeftKey) {        

			if (moveDownKey && !moveUpKey) {         // Down-Right

					Motor.X_MaxSpeed = PlayerSpeed_Diagonal;
					Motor.Y_MaxSpeed = -PlayerSpeed_Diagonal;

			} else if (moveUpKey && !moveDownKey) {     // Down-Right

					Motor.X_MaxSpeed = PlayerSpeed_Diagonal;
					Motor.Y_MaxSpeed = PlayerSpeed_Diagonal;

			} else {                                          // Rigth

					Motor.X_MaxSpeed = PlayerSpeed;
					Motor.Y_MaxSpeed = 0;

			}
		} else {

			if (moveDownKey && !moveUpKey) {         // Down
			
					Motor.X_MaxSpeed = 0;
					Motor.Y_MaxSpeed = -PlayerSpeed;
			
			} else if (moveUpKey && !moveDownKey) {     // Up
			
					Motor.X_MaxSpeed = 0;
					Motor.Y_MaxSpeed = PlayerSpeed;
			
			} else {                                          // Middle
			
					Motor.X_MaxSpeed = 0;
					Motor.Y_MaxSpeed = 0;
			
			}
		}
		/***********************************************
	 	**********************************************/

		//Jump
		/***********************************************
	 	**********************************************/
		if (jumpKey) {
		
			Motor.Jump = true;
			Motor.Z_MaxSpeed = -JumpSpeed;
		
		}
		/***********************************************
	 	**********************************************/


		//Go to menus ans give them Input control
		if (gameMenuKey) {
		
			GameObject.Find("GameMenu").GetComponent<GameMenuGUI>().isActive = true;
			this.isActive = false;
		
		}
	
		if (characterMenuKey) {
		
			GameObject.Find("CharacterMenu").GetComponent<CharacterMenuGUI>().isActive = true;
			this.isActive = false;
		
		}

	}







}
