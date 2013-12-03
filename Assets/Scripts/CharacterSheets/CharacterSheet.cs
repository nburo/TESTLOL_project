using UnityEngine;
using System.Collections;

public class CharacterSheet : MonoBehaviour {

	//Definitions
	public struct Skill { 
		float TimeLeft;
		float Cooldown;
	}
	public struct Equipment { 
		string Name;
		string Type;
		int Modifier;
	}

	public enum SexType {Male=0, Female, Other};



	//Character Info
	public string Name;
	public SexType Sex;

	public int Level { 
				get; 
		
				private set;
	}

	public int CurrentHealth { get; set;}
	public int MaximumHealth { 
				get;
		
				private set;
	}
	
	public Skill[] SelectedSkills;


	//  Statistics
	public int Burliness { 
				get;

				private set;
	}

	public int Deftness { 
				get;
		
				private set;
	}

	public int Toughness { 
				get;
		
				private set;
	}

	public int Swiftness { 
				get;
		
				private set;
	}



	


	// Inventory
	public Equipment[] InventoryItem;



}
