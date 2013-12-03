using UnityEngine;
using System.Collections;

public class PlayerSheet : CharacterSheet {

	enum PlayerClass {Rouge=0, Mage, Pirate, Archer};





	public int Experience { 
				get;
		
				set;
	}

	public int ExperienceToNextLevel;






	public void Levelup(){



	}


	// Equipment
	public Equipment Helmet;
	public Equipment Armor;
	public Equipment RightHand;
	public Equipment LeftHand;
	public Equipment Gloves;
	public Equipment Boots;

}
