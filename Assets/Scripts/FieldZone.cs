using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldZone : MonoBehaviour 
{
	public FieldSlot LeftSlot;
	public FieldSlot MidSlot;
	public FieldSlot RightSlot;

	public int SlotsCount;
	//List<FieldSlot> Slots = new List<FieldSlot>();
	public Zones ZoneType;
	public int FreeSlots = 0;
	public List<FieldSlot> mySlots = new List<FieldSlot>();
	public List<PlayerMarker> myMarkers = new List<PlayerMarker>();

	// Generate list of attached slots 
	void Start()
	{
		foreach( FieldSlot f in GetComponentsInChildren<FieldSlot>() )
		{
			mySlots.Add (f);
		}
	}
	//Adds marker to zone if possible, else return it back
	public void AttachMarker(PlayerMarker p)
	{
		int OpenSlots = mySlots.Count - myMarkers.Count;

		switch (OpenSlots)
		{
		case 0:
			//no slots, revert
			Revert (p);
			break;
		case 1|3:
			//go mid
			Move(p, SlotType.M);
			myMarkers.Add (p);
			break;
		case 2:
			//go left, mid goes right
			Move (p, SlotType.L);
			myMarkers.Add (p);
			Move (myMarkers[0], SlotType.R);

			break;
		}
	}

	public void DetachMarker(PlayerMarker p)
	{
		int Slots = p.myZone.mySlots.Count;
		int Markers = p.myZone.myMarkers.Count;
		int OpenSlots = Slots - Markers;

		if (OpenSlots==0 && Slots==1)
		{
			p.myZone.myMarkers.Remove(p);
			return;
		}

		switch(OpenSlots)
		{
		case 2:
			//return, only one slot occupied
			return;
		case 1:
			//go mid

			break;
		case 0:
			//if mid - ok, left: mid go right, right: mid gp left

			break;
		}
	}

	//finds slot, assign value and move marker
	void Move(PlayerMarker p, SlotType s)
	{
		FieldSlot t;

		foreach(FieldSlot f in mySlots)
		{
			if(f.Type==s)
			{
				t=f;
				p.mySlot=t;
				p.transform.position=t.transform.position;
				break;
			}
		}
	}

	//revert marker drag
	void Revert(PlayerMarker p)
	{
		p.transform.position = p.LastPosition.position;
	}

	/*
	public void Attach(PlayerMarker p)
	{


		foreach(FieldSlot f in Slots)
		{
			FreeSlots = f.Available == true ? FreeSlots++ : FreeSlots;
		}

		switch (FreeSlots)
		{
		case 1 | 3:

			p.

			Slots[M].Available=false;
			p.transform.position = Slots[M].transform.position;
			
			break;
		case 2:

			Transform n = MidSlot.GetComponentInChildren<PlayerMarker>().transform;
			n.position = n.transform.parent.position;
			
			p.transform.position = p.transform.parent.position;
			
			break;
		case 0:
			
			p.RevertMovement(p);
			
			break;
		}
	}
	*/
/*
	void Detach(PlayerMarker p)
	{
		SlotType TempSlot;

		p.mySlot.Available=true;

		switch (p.myZone.FreeSlots)
		{
		case 1:
			//2 or 0 markers left


			break;
		case 2:
			//get last ont and set it to M
			break;
		default:
			//3 free slots, noting to do 
			break;
		}

		

	}
	/*
	void Attach(PlayerMarker p)
	{
		switch(SlotsCount)
		{
		case 1 | 3:
			p.transform.parent = MidSlot.transform;
			p.transform.position = p.transform.parent.position;

			break;
		case 2:
			Transform n = MidSlot.GetComponentInChildren<PlayerMarker>().transform;

			n.parent = LeftSlot.transform;
			n.position = n.transform.parent.position;

			p.transform.parent = RightSlot.transform;
			p.transform.position = p.transform.parent.position;

			break;
		case 0:

			p.RevertMovement(p);

			break;
		}
	}	
*/
}
