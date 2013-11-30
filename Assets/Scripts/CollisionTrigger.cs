using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour 
{

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "staticObjects") 
		{
			Debug.Log ("Enter static trigger");
		}
		else if (col.gameObject.tag == "dynamicObjects")
		{
			Debug.Log ("Enter dynamic trigger");
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "staticObjects") 
		{
			Debug.Log ("Exit static trigger");
		}
		else if (col.gameObject.tag == "dynamicObjects")
		{
			Debug.Log ("Exit dynamic trigger");
		}
	}
}
