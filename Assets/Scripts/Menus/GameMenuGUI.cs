using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMenuGUI : MenuHandle {

	public Color MenuBackgroundcolor;
	private Texture2D BlankTexture;
	public GUIStyle textStyle;

	void Awake(){
		isActive = false;


		Init ();
		MenuRoot.text = "Menu Root";

		MenuRoot.item = new List<MenuItem>();
		MenuRoot.item.Add(new MenuItem());
		MenuRoot.item.Add(new MenuItem());
		MenuRoot.item[1].item = new List<MenuItem>();
		MenuRoot.item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item[1].item = new List<MenuItem>();
		MenuRoot.item[1].item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item[1].item.Add(new MenuItem());
		MenuRoot.item[1].item.Add(new MenuItem());
		MenuRoot.item.Add(new MenuItem());

		MenuRoot.item[0].text = "Back";
		MenuRoot.item[1].text = "Options";
		MenuRoot.item[1].item[0].text = "Back";
		MenuRoot.item[1].item[1].text = "Graphics";
		MenuRoot.item[1].item[1].item[0].text = "Back";
		MenuRoot.item[1].item[1].item[1].text = "VSync On/Off";
		MenuRoot.item[1].item[1].item[2].text = "Luminosity";
		MenuRoot.item[1].item[1].item[3].text = "Texture Quality";
		MenuRoot.item[1].item[2].text = "Controls";
		MenuRoot.item[2].text = "Quit";




		Debug.Log ("GameMenuGUI.Awake()");

		BlankTexture = new Texture2D (1, 1);
		textStyle = new GUIStyle();
	}
	

	void Update () {

		if (ItemActivated) {

			if(CurrentItem.item[ActiveItem[ActiveItem.Count - 1]].text == "Quit"){
				Application.Quit();
			}

			if(CurrentItem.item[ActiveItem[ActiveItem.Count - 1]].text == "Back"){
				ItemActivated = false;
				StepOut();
			}

			ItemActivated = false;
		}
	
	}

	void OnGUI(){

		if (isActive) {

			GUI.skin.box.normal.background = BlankTexture;

			BlankTexture.SetPixel(0,0,MenuBackgroundcolor);
			BlankTexture.Apply ();
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),
			                BlankTexture);


			for(int i =0; i<CurrentItem.item.Count;i++){
				if(i==ActiveItem[ActiveItem.Count-1]){
					GUI.Label(new Rect(Screen.width/2, Screen.height*(2+i)/6, 100, 20),
					          CurrentItem.item[i].text,textStyle);
				}else {
					GUI.Label(new Rect(Screen.width/2, Screen.height*(2+i)/6, 100, 20),
					          CurrentItem.item[i].text);
				}

			}

		




				}

	}

}
