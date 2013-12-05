using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {
	
	private bool menuLeftKey;
	private bool menuRightKey;
	private bool menuUpKey;
	private bool menuDownKey;
	private bool menuStepOutKey;
	private bool menuStepInKey;
	private bool menuCloseKey;

	private MenuHandle menu;
	private bool isActive;

	private bool firstScan;


	//Initialise the menu
	void Start (){

		menu = this.GetComponent<MenuHandle> ();
		isActive = menu.isActive;
		firstScan = true;

		}
	
	void Update () {

		isActive = menu.isActive;

		if (isActive){

			//Read InputS
			/*****************************************
		 	*****************************************/
			menuLeftKey = Input.GetKeyDown(KeyCode.LeftArrow);
			menuRightKey = Input.GetKeyDown(KeyCode.RightArrow);
			menuUpKey = Input.GetKeyDown(KeyCode.UpArrow);
			menuDownKey = Input.GetKeyDown(KeyCode.DownArrow);
			menuStepOutKey = /*Input.GetKeyDown(KeyCode.Escape) ||*/ Input.GetKeyDown(KeyCode.Z);
			menuStepInKey = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X);
			menuCloseKey = Input.GetKeyDown(KeyCode.Escape);
			/*****************************************
		 	*****************************************/


			//Process Inputs
			/*****************************************
		 	*****************************************/
			if (!firstScan){
				if (menuCloseKey) { // Step out one level
					menu.Close();
				} else if (menuStepOutKey) { // Step out one level
					menu.StepOut();
				} else if (menuUpKey) { // Change Active Item
					menu.PreviousItem();
				} else if (menuDownKey) { // Change Active Item
					menu.NextItem();
				} else if (menuLeftKey) { // Needed?

				} else if (menuRightKey) { // Needed?

				} else if (menuStepInKey) { // Step in one level
					menu.StepIn();
				}
			}
			/*****************************************
		 	*****************************************/


			firstScan = false;

		} else{

			//Reset Inputs
			/*****************************************
		 	*****************************************/
			menuLeftKey = false;
			menuRightKey = false;
			menuUpKey = false;
			menuDownKey = false;
			menuStepOutKey = false;
			menuStepInKey = false;
			/*****************************************
		 	*****************************************/

			firstScan = true;
		}

	}

}




