using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour
{
	public GameObject JerseyCur;
	public GameObject PickedObj;
	public FPlayer LinkedPlayer;
	public GameObject LastZone;
	public GameObject Field;
	public bool Lighted=false;

	
	//Highlight available slots on field
	void OnMouseDown()
	{
		SlotHighlight();
	}


	void SlotHighlight()
	{
		foreach (FieldSlot Slot in Field.GetComponent<SlotManager>().AvailableFieldSlots)
		{
			Slot.VisibilitySwitch();
		}
	}

	void OnMouseDrag()
	{
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
	}

	public void ColliderSwitch()
	{
		foreach (BoxCollider Box in GetComponentsInChildren<BoxCollider>())
		{
			Box.enabled=!Box.enabled;
		}
	}
		
	public RaycastHit GetTarget()
	{
		Ray DropRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit Hit;
		Physics.Raycast (DropRay, out Hit);
		return Hit;
	}

	void OnMouseUp()
	{
		Debug.Log ("Mouse Up");
		SlotHighlight ();
		ColliderSwitch ();
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
	
		ColliderSwitch ();

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

	public void Apply( PlayerMarker m, FPlayer p)
	{
		m.LinkedPlayer = p;
	}

	public void Swap( PlayerMarker p)
	{
		//swap player links between two markers
		FPlayer TempSlot;

		TempSlot = this.LinkedPlayer;

		this.LinkedPlayer = p.LinkedPlayer;
		p.LinkedPlayer = TempSlot;
		//!!!need to update jerseys
	}

	public void RevertMovement( PlayerMarker p)
	{
		//place marker on last fitted position
		p.transform.position = p.transform.parent.position;
	}

	public void Move()
	{
		//find new slot, place, rearrange other markers
		//rearrange other markers in LaztZone
	}

}
