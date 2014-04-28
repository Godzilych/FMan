using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamRoster : MonoBehaviour 
{
	public GameObject FPlayerPrefab;
	public GameObject[] FPlayerList;

	public class Formation
	{
		public Dictionary<GameObject,GameObject> MarkerPositions;
	}

	// Use this for initialization
	void Start () 
	{
		for(int i=0; i < FPlayerList.Length; i++)
		{
			GameObject item = Instantiate( FPlayerPrefab) as GameObject;
			item.transform.parent = gameObject.transform;
		}
	}
}
