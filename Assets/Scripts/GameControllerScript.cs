using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerScript : MonoBehaviour {

	public GameObject Field;
	public Selector selected = null;


	// Use this for initialization
	void Start () {
	
	}

	public void PlayerSwap (Selector player1, Selector player2)
	{
		Transform player1parent = player1.transform.parent;
		Transform player2parent = player2.transform.parent;
		Vector3 player1pos = player1.transform.position;
		Vector3 player2pos = player2.transform.position;

		player1.transform.parent = player2parent;
		player1.transform.position = player2pos;
		player2.transform.parent = player1parent;
		player2.transform.position = player1pos;
	}

	public void PlayerSet(Selector p)
	{
		SlotsManager CurrentSlots = p.GetComponent<SlotsManager> ();

		if (CurrentSlots.SlotsNumber.Length == 1)
		{
			Debug.Log ("One slot");
			if (CurrentSlots.SlotsNumber[0].activeInHierarchy == true) 
			{
				Debug.Log ("Slot aviable");
				CurrentSlots.SlotsNumber[0].SetActive(false);
				selected.transform.position=CurrentSlots.SlotsNumber[0].transform.position;
				selected.transform.parent=CurrentSlots.SlotsNumber[0].transform.parent;
			} 
			else 
			{
				//swap players
			}
		} 
		else if (CurrentSlots.SlotsNumber[0].activeInHierarchy == false && CurrentSlots.SlotsNumber[1].activeInHierarchy == false) 
		{
			Debug.Log ("Slots are full");
		} 
		else if (CurrentSlots.SlotsNumber[0].activeInHierarchy == false && CurrentSlots.SlotsNumber[1].activeInHierarchy == true) 
		{
			//attach to slot1 and slot0 put into slot2
		}
		else if (CurrentSlots.SlotsNumber[0].activeInHierarchy == true)
		{
			//attach to slot0
		}
	}

	public void PlayerPlacing(Selector p)
	{
		if (selected == null && p.tag=="Footballer") 
		{
			selected = p;
			Debug.Log("first select:",p);
		} 
		else if (selected == p) 
		{
			Debug.Log("deselect",p);
			selected = null;
		} 
		else if (p.tag == "Footballer")
		{
			PlayerSwap(selected, p);
			Debug.Log("Swap", p);
			selected = null;
		}
		else if (selected != null && p.tag == "FieldZone")
		{
			PlayerSet(p);
			Debug.Log("Place",p);
			selected = null;
			// если цель пустое поле, то постановка в слот по логике
		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
