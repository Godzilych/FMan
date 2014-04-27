using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldSlot : MonoBehaviour 
{
	public SlotType Type;

	List<MeshRenderer> Parts = new List<MeshRenderer>();
	
	public void VisibilitySwitch()
	{
		foreach(MeshRenderer M in Parts)
		{
			M.enabled=!M.enabled;
		}
	}

	void Start()
	{
		foreach(MeshRenderer M in gameObject.GetComponentsInChildren<MeshRenderer>())
		{
			Parts.Add(M);
		}
	}
}