using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuHandle : MonoBehaviour {

	// Definition of a Menu Item
	public class MenuItem{
		public string text;
		public List<MenuItem> item;
	}


	public bool isActive;

	public List<int> ActiveItem;
	public MenuItem MenuRoot;
	
	public MenuItem CurrentItem;
	public bool ItemActivated;


	public void Init(){

		MenuRoot = new MenuItem ();
		ActiveItem = new List<int>();
		ActiveItem.Add(0);

	}

	public void Start(){
		CurrentItem = new MenuItem ();
		CurrentItem.item = new List<MenuItem>();
		CurrentItem = MenuRoot;
		ItemActivated = false;

		Debug.Log ("MenuHandle.Start()");
	}


	public void Close () {

		GameObject.Find("Player").GetComponent<PlayerInput>().isActive = true;
		isActive = false;

		ActiveItem.Clear();
		ActiveItem.Add(0);
		CurrentItem = MenuRoot;
		ItemActivated = false;

		Debug.Log ("Close()");
	}

	//Select Next Item
	public void NextItem () {
		if (!ItemActivated) {
			if (ActiveItem [ActiveItem.Count-1] == CurrentItem.item.Count - 1) {
				ActiveItem[ActiveItem.Count-1] =  0;
			} else { ActiveItem [ActiveItem.Count - 1]++; }
		}
		Debug.Log ("NextItem()  " + ActiveItem [ActiveItem.Count-1] );
	}

	//Select Previous Item
	public void PreviousItem () {

		if (!ItemActivated) {
			if (ActiveItem [ActiveItem.Count-1] == 0) {
				ActiveItem[ActiveItem.Count-1] =  CurrentItem.item.Count - 1;
			} else { ActiveItem [ActiveItem.Count - 1]--; }
		}
		Debug.Log ("PreviousItem()  " + ActiveItem [ActiveItem.Count-1] );
	}


	//Step In if there is a sub-menu.
	public void StepIn () {

		if (CurrentItem.item[ActiveItem[ActiveItem.Count - 1]].item == null) {
			Debug.Log ("failed");
			ItemActivated = true;
		} else {

			CurrentItem = CurrentItem.item[ActiveItem[ActiveItem.Count - 1]];
			ActiveItem.Add(0);

			Debug.Log ("StepIn()  " + ActiveItem.Count);

		}

	}

	// Step out, or close if we are already at root
	public void StepOut () {
		if (!ItemActivated) {
			if (ActiveItem.Count>1) {
				ActiveItem.RemoveAt(ActiveItem.Count-1);

				CurrentItem = MenuRoot;
				for(int i=1; i<ActiveItem.Count; i++){
					CurrentItem = CurrentItem.item[ActiveItem[i]];
				}

				Debug.Log ("StepOut()");
					
			} else {this.Close();}

		} else{ItemActivated = false;}

	}
	

}










