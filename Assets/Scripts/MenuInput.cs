using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {

	public bool isActive = false;


	private bool menuLeftKey;
	private bool menuRightKey;
	private bool menuUpKey;
	private bool menuDownKey;
	private bool menuEscapeKey;
	private bool menuEnterKey;

	private int ActiveItem = 0;


	//Initialise the menu
	void Start (){


		}



	void OnGUI() {
		 
		}



	void Update () {
		if (isActive){

			//Read input
			/*****************************************
		 	*****************************************/
			menuLeftKey = Input.GetKeyDown(KeyCode.LeftArrow);
			menuRightKey = Input.GetKeyDown(KeyCode.RightArrow);
			menuUpKey = Input.GetKeyDown(KeyCode.UpArrow);
			menuDownKey = Input.GetKeyDown(KeyCode.DownArrow);
			menuEscapeKey = Input.GetKeyDown(KeyCode.Escape);
			menuEnterKey = Input.GetKeyDown(KeyCode.Return);
			/*****************************************
		 	*****************************************/


			//Process Input
			/*****************************************
		 	*****************************************/
			if (menuEscapeKey) { // Step out one level

			} else if (menuUpKey) { // Change Active Item

			} else if (menuDownKey) { // Change Active Item

			} else if (menuLeftKey) { // Needed?

			} else if (menuRightKey) { // Needed?

			} else if (menuEnterKey) { // Step in one level

			}
			/*****************************************
		 	*****************************************/
		}

	}



}
