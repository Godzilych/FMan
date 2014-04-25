using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldZone : MonoBehaviour 
{
	public FieldSlot LeftSlot;
	public FieldSlot MidSlot;
	public FieldSlot RightSlot;
	public int SlotsCount;
	public int FreeSlotsCount;
	
	void Start()
	{
		SlotsCount = transform.childCount;
		FreeSlotsCount = SlotsCount;
	}

	void Attach(PlayerMarker p)
	{
		switch(SlotsCount)
		{
		case 1 | 3:
			p.transform.parent = MidSlot.transform;
			p.transform.position = p.transform.parent.position;

			FreeSlotsCount--;

			break;
		case 2:
			Transform n = MidSlot.GetComponentInChildren<PlayerMarker>().transform;

			n.parent = LeftSlot.transform;
			n.position = n.transform.parent.position;

			p.transform.parent = RightSlot.transform;
			p.transform.position = p.transform.parent.position;

			FreeSlotsCount--;

			break;
		case 0:

			p.RevertMovement(p);

			break;
		}
	}

	void Arrange( FieldZone z)
	{
		z.FreeSlotsCount--;

		switch (z.SlotsCount-z.FreeSlotsCount)
		{
		case 1:

			//z.gameObject.
			break;
		case 2:

			break;
		}
	}
}
