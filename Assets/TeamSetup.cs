using UnityEngine;
using System.Collections;

public class TeamSetup : MonoBehaviour
{
	public int FieldPlayersCount;
	public int SubPlayersCount;
	public int KeepersCount;

	public class FPlayerOnField : FPlayer
	{
		 
	}

	void Start ()
	{
		for (int i=0; i < FieldPlayersCount; i++) 
		{
				//Инстанцируются маркеры
		}
	}

}