using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMarker : MonoBehaviour
{
	public GameObject JerseyCur;
	public GameObject LastZone;
	public SlotManager Field;

	public FPlayer LinkedPlayer;
	public FieldZone myZone;
	public FieldSlot mySlot;
	public Transform LastPosition;

	private List<Collider> myColliders = new List<Collider>();

	//Generate childrens collider list
	void Start()
	{
		foreach (Collider Box in GetComponentsInChildren<Collider>())
		{
			myColliders.Add (Box);
		}
	}

	//Highlight available slots on field then mouse1 pressed
	void OnMouseDown()
	{
		SlotHighlight();
		LastPosition = transform;
	}

	//Switch visibility state of field slots
	void SlotHighlight()
	{
		foreach (FieldSlot Slot in Field.AvailableFieldSlots)
		{
			Slot.VisibilitySwitch();
		}
	}

	//Move selected marker
	void OnMouseDrag()
	{
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
	}

	//Switch current marker colliders state while raycasting
	public void ColliderSwitch()
	{
		foreach (Collider Box in myColliders)
		{
			Box.enabled=!Box.enabled;
		}
	}

	//Detects and return drop target for dragged object
	public RaycastHit GetTarget()
	{
		ColliderSwitch();
		Ray DropRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit Hit;
		Physics.Raycast (DropRay, out Hit);
		ColliderSwitch();
		return Hit;
	}
	//Change draged marker parameters depends on drop target
	void OnMouseUp()
	{
		SlotHighlight ();
		/*
		Ray DropRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit Hit;
		Debug.DrawRay (DropRay.origin, DropRay.direction*10, Color.green, 5);
		*/
		GameObject Target = GetTarget ().collider.gameObject;

		switch (Target.tag) 
		{
		case "FieldZone":
			if(Target.transform==this.transform.parent)
			{
				RevertMovement (this);
			}
			//Move marker or revert movement
			Target.GetComponent<FieldZone>().AttachMarker(this);
			break;
		case "PlayerMarker":
			//Swap linked players, revert movement
			Swap (Target.GetComponent<PlayerMarker> ());

			break;
		case "TeamRoster":
			//Link player to marker of switch two linked players
			Apply (this, Target.GetComponent<FPlayer>());

			break;
		default:
			//revert movement
			break;
		}
		/*
		if (Physics.Raycast (DropRay.origin,DropRay.direction*10, out Hit ))
		{
			if(Hit.collider.gameObject.tag =="FieldZone")
			{
				Debug.Log ("Zone Hit");
				//place or placeback

			}
			else if(Hit.collider.gameObject.tag =="PMarker")
			{
				Debug.Log ("Marker Hit");
				//swap
			}
			else if (Hit.collider.gameObject.tag =="TeamRooster")
			{
				Debug.Log ("WTF!");
				//apply or switch
			}
			Debug.Log (Hit.collider.gameObject);
		}
		else
		{
			Debug.Log("Missed Ray");
			ColliderSwitch();
			//revert
		}*/
	}

	//Atttach player to the marker
	public void Apply( PlayerMarker m, FPlayer p)
	{
		m.LinkedPlayer = p;
	}

	//Swap attached players between two markers
	public void Swap( PlayerMarker p)
	{
		//swap player links between two markers
		FPlayer TempSlot;

		TempSlot = this.LinkedPlayer;

		this.LinkedPlayer = p.LinkedPlayer;
		p.LinkedPlayer = TempSlot;
		//!!!need to update jerseys
	}

	//Move marker to position where it was picked
	public void RevertMovement( PlayerMarker p)
	{
		//place marker on last fitted position
		p.transform.position = p.LastPosition.position;
	}

	public void Move()
	{
		//find new slot, place, rearrange other markers
		//rearrange other markers in LaztZone
	}

}
