using UnityEngine;
using System.Collections;

public class UIDraw : MonoBehaviour {

	public bool GreyScreen = false;
	public Color GreyScreenColor;

	public float Health;
	public float MaxHealth;
	public int HealthBarWidth;
	public int HealthBarHeight;
	public Color HealthBarActiveColor;
	public Color HealthBarInactiveColor;
	public Texture HealthBarFrameTexture;

	public Texture[] skillTexture;
	public Texture InactiveSkillBorderTexture;
	public Texture ActiveSkillBorderTexture;
	public int skillTextureSize;
	public int skillSpacing;

	private Texture2D BlankTexture;
	private Texture2D defaultBoxBackground;
	private Rect[] SkillTexturesRect;

	void Start () {
		BlankTexture = new Texture2D (1, 1);
	}

	void Update () {
	
	}



	void OnGUI(){

		//Initialize
		GUI.skin.box.normal.background = BlankTexture;

			

		// Draw Skills icons

		for(int i=0;i<skillTexture.Length;i++){
			GUI.DrawTexture(new Rect(Screen.width/3 - 200+(skillTextureSize+skillSpacing)*i,
			                 Screen.height-skillTextureSize-8, 
			                 skillTextureSize, skillTextureSize), skillTexture[i]);
			GUI.DrawTexture(new Rect(Screen.width/3 - 200+(skillTextureSize+skillSpacing)*i,
			                         Screen.height-skillTextureSize-8, 
			                         skillTextureSize, skillTextureSize), InactiveSkillBorderTexture);

		}

		// Draw Health Bar
			
		BlankTexture.SetPixel(0,0,HealthBarInactiveColor);
		BlankTexture.Apply ();
		GUI.DrawTexture(new Rect(Screen.width/10+HealthBarWidth*(Health/MaxHealth),Screen.height/20, HealthBarWidth*(1-(Health/MaxHealth)), HealthBarHeight),
		                BlankTexture);

		BlankTexture.SetPixel(0,0,HealthBarActiveColor);
		BlankTexture.Apply ();
		GUI.DrawTexture(new Rect(Screen.width/10,Screen.height/20, HealthBarWidth*(Health/MaxHealth), HealthBarHeight),
		                BlankTexture);

		//GUI.DrawTexture(HealthBarFrameTexture)

		//BlankTexture.SetPixel(0,0,Color.clear);
		//BlankTexture.Apply ();
		//GUI.skin.box.normal.background = BlankTexture;

		//GUI.EndGroup();


		//Grey Screen
		if (GreyScreen) {
			BlankTexture.SetPixel(0,0,GreyScreenColor);
			BlankTexture.Apply ();
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),
			                BlankTexture);

		}

	}
}
