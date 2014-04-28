using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMarker : MonoBehaviour
{
	public GameObject JerseyCur;
	public SlotManager Field;

	public FPlayer LinkedPlayer;
	public FieldZone myZone;
	public FieldSlot mySlot;
	public Vector3 LastPosition = new Vector3();

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
		LastPosition = transform.position;
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

		GameObject Target = GetTarget ().collider.gameObject;

		switch (Target.tag) 
		{
		case "FieldZone":
			//Move marker or revert movement
			Target.GetComponent<FieldZone>().AttachMarker(this);
			break;
		case "PlayerMarker":
			//Swap linked players, revert movement
			Swap (Target.GetComponent<PlayerMarker> ());
			Revert ();

			break;
		case "TeamRoster":
			//Link player to marker of switch two linked players
			Apply (this, Target.GetComponent<FPlayer>());
			Revert ();

			break;
		default:
			//revert movement
			Revert ();
			break;
		}
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

	//Revert movement
	public void Revert()
	{
		transform.position=LastPosition;
	}
}