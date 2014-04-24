using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamList : MonoBehaviour
{
	public GameObject FootballerPrefab;
	public int TeamSize;
	public List<Footballer> Team = new List<Footballer>();



	public string NameGenerator()
	{
		string[] NameList = {"Vasya", "Kolya", "Ivan", "Joseph", "Afonasiy", "Petr", "Fedeor", "Akakiy", "Frank", "Garret", "Mikael", "Brian"};
		string[] FamnameList = {"Kapusta", "Kardan", "Sukhodryshev", "Ivanov", "Putin", "Ronaldo", "Gonsalez", "Arshavin", "Kerzhakov"};

		return string.Concat(Random.Range(0,NameList.Length)," ",Random.Range(0,FamnameList.Length));
	}

	void Start()
	{
		for(int i=0; i < TeamSize; i++)
		{
			Team.Add( new Footballer(NameGenerator(), Random.Range (0,200)));
			Debug.Log ("qq");
		}
	}

}
