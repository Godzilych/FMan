using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour
{
	public GameObject JerseyCur;
	public GameObject PickedObj;
	public FPlayer LinkedPlayer;
	public GameObject LastZone;

	
	//void OnMouseDown()
	//{
	//	Debug.Log("Clicked");
	//	JerseyCur.GetComponent<Jersey> ().JerseyUpdate ("Колян", "00");
	//}

	void OnMouseDrag()
	{
		//подсветка слотов
		//перемещение объекта за мышкой

		gameObject.layer = 2;
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
	}

	public void ColliderSwitch()
	{
		foreach (BoxCollider Box in GetComponentsInChildren<BoxCollider>())
		{
			Box.enabled=!Box.enabled;
		}
	}

	public void GetDropZone( GameObject p)
	{

	}

	void OnMouseUp()
	{
		Debug.Log ("Mouse Up");
		ColliderSwitch ();
		Ray DropRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit Hit;
		Debug.DrawRay (DropRay.origin, DropRay.direction*10, Color.green, 5);

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
		}
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
	}

	public void Move()
	{
		//find new slot, place, rearrange other markers
		//rearrange other markers in LaztZone
	}

}
