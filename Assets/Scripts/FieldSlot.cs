using UnityEngine;
using System.Collections;

public class FieldSlot : MonoBehaviour 
{
	public bool isAvaliable = true;

	public void StateSwitch()
	{
		isAvaliable = !isAvaliable;
	}

	public void VisibilitySwitch()
	{
		gameObject.GetComponentInChildren<MeshRenderer> ().enabled = !gameObject.GetComponentInChildren<MeshRenderer> ().enabled;
	}
}
