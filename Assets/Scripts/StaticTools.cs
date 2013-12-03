using UnityEngine;
using System.Collections;

public class StaticTools : MonoBehaviour {

	public static char CollisionDectection(Bounds moi, Bounds toi)
	{
		char sides;

		Vector3 moiMax = moi.max;
		Vector3 moiMin = moi.min;

		Vector3 toiMax = toi.max;
		Vector3 toiMin = toi.min;

		//toiMax
		Vector3 maxMinusMin = new Vector3(Mathf.Abs(moiMax.x - toiMin.x),Mathf.Abs(moiMax.y - toiMin.y),Mathf.Abs(moiMax.z - toiMin.z));
		Vector3 minMinusMax = new Vector3(Mathf.Abs(moiMin.x - toiMax.x),Mathf.Abs(moiMin.y - toiMax.y),Mathf.Abs(moiMin.z - toiMax.z));

		if(maxMinusMin.x <= maxMinusMin.y && 
		   maxMinusMin.x <= minMinusMax.y)
			return 'r';
		if(minMinusMax.x <= minMinusMax.y &&
		   minMinusMax.x <= maxMinusMin.y)
			return 'l';
		if(maxMinusMin.y <= minMinusMax.x && 
		   maxMinusMin.y <= maxMinusMin.x)
			return 'u';
		if(minMinusMax.y <= minMinusMax.x && 
		   minMinusMax.y <= maxMinusMin.x)
			return 'd';

		return 'n';

	}

}
