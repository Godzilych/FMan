﻿using UnityEngine;
using System.Collections;

public class FieldSlot : MonoBehaviour 
{

	public void VisibilitySwitch()
	{
		foreach(MeshRenderer M in gameObject.GetComponentsInChildren<MeshRenderer>())
		{
			M.enabled=!M.enabled;
		}
	}
}