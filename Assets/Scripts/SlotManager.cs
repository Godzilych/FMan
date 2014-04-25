using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotManager : MonoBehaviour 
{
	public List<FieldSlot> AvailableFieldSlots = new List<FieldSlot>();


	void Start () 
	{
		foreach( FieldSlot Slot in GetComponentsInChildren<FieldSlot>())
		{
			AvailableFieldSlots.Add(Slot);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}	
}
