using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldZone : MonoBehaviour 
{
	public Zones ZoneType;
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
		if(this==p.myZone)
		{
			p.Revert ();
			return;
		}

		int OpenSlots = mySlots.Count - myMarkers.Count;

		switch (OpenSlots)
		{
		case 0:
			//no slots, revert
			p.Revert ();
			Debug.Log ("no slots");
			break;
		case 1:
			//go mid
			DetachMarker(p);
			Move(p, SlotType.M);
			myMarkers.Add (p);
			break;
		case 3:
			//go mid
			DetachMarker(p);
			Move(p, SlotType.M);
			myMarkers.Add (p);
			break;
		case 2:
			//go left, mid goes right
			DetachMarker(p);
			Move (p, SlotType.L);
			myMarkers.Add (p);
			Move (myMarkers[0], SlotType.R);
			break;
		}
	}

	public void DetachMarker(PlayerMarker p)
	{
		//no detach on first attach
		if(p.myZone == null)
		{
			return;
		}

		int Slots = p.myZone.mySlots.Count;
		int Markers = p.myZone.myMarkers.Count;
		int OpenSlots = Slots - Markers;

		Debug.Log (OpenSlots); 

		if (OpenSlots==0 && Slots==1)
		{
			//
			p.myZone.myMarkers.Remove(p);
			return;
		}

		switch(OpenSlots)
		{
		case 2:
			//return, only one slot occupied
			p.myZone.myMarkers.Remove(p);
			return;
		case 1:
			//
			foreach(PlayerMarker pp in p.myZone.myMarkers.ToArray())
			{
				if(pp!=p)
				{
					Debug.Log ("move to mid");
					FixPositions (pp,SlotType.M);
					p.myZone.myMarkers.Remove(p);
					return;
				}
			}
			break;
		case 0:
			//if mid - ok, left: mid go right, right: mid gp left
			switch(p.mySlot.Type)
			{
			case SlotType.M:
				// mid, ok, remove
				p.myZone.myMarkers.Remove(p);
				break;
			case SlotType.L:
				//left, mid go right
				foreach(PlayerMarker pp in p.myZone.myMarkers.ToArray())
				{
					if(pp.mySlot.Type==SlotType.M)
					{
						FixPositions(pp, SlotType.L);
						p.myZone.myMarkers.Remove(p);
						return;
					}
				}
				break;
			case SlotType.R:
				//right, mid goes left
				foreach(PlayerMarker pp in p.myZone.myMarkers.ToArray())
				{
					if(pp.mySlot.Type==SlotType.M)
					{
						FixPositions (pp, SlotType.R);
						p.myZone.myMarkers.Remove(p);
						return;
					}
				}
				break;
			}
			break;
		}
	}

	//set correct position for markers in left zone
	void FixPositions(PlayerMarker o, SlotType s)
	{
		foreach(FieldSlot f in o.myZone.mySlots)
		{
			if(f.Type==s)
			{
				o.transform.position=f.transform.position;
				break;
			}
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
				p.myZone=this;
				p.mySlot=t;
				p.transform.position=t.transform.position;
				break;
			}
		}
	}
}