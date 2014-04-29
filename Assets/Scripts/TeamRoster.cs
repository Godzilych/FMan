using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamRoster : MonoBehaviour 
{
	public int TeamSize;

	public GameObject EntryPrefab;
	public FPlayer FPlayerPrefab;
	public FPlayer[] FPlayerList;
	
	// Use this for initialization
	void Start () 
	{
		for(int i=0; i < TeamSize; i++)
		{
			GameObject Entry = Instantiate(EntryPrefab,gameObject.transform.position+new Vector3(0,4-i/2.0f,0),Quaternion.identity) as GameObject;
			Entry.transform.parent = gameObject.transform;
		}
	}

}
