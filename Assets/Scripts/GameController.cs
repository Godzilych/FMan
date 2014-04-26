using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Zones 
{
	GK, //goalkeeper
	//Defence	
	SW, DC,	FL,	FR,	WL,	WR,
	//Midfield
	DM,	CM,	AM,	ML,	MR,
	//Attack
	AML, FC, AMR
};
public enum SlotType {L, M, R};

public class GameController : MonoBehaviour
{
	public int FieldPlayersCount;
	public int SubPlayersCount;
	public int KeepersCount;

	public GameObject PlayerMarkerPrefab;
	public GameObject Team;
	public GameObject Field;

	public List<PlayerMarker> TeamLineup = new List<PlayerMarker>();


	void Start ()
	{
		for (int i=0; i < FieldPlayersCount; i++) 
		{
				//Инстанцируются маркеры
			GameObject p = Instantiate(PlayerMarkerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			p.transform.parent=Team.transform;
			p.GetComponent<PlayerMarker>().Field=Field.GetComponent<SlotManager>();
			TeamLineup.Add(p.GetComponent<PlayerMarker>());

		}

	}

}