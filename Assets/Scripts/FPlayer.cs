using UnityEngine;
using System.Collections;

public class FPlayer : MonoBehaviour
{
	public enum Positions {CD, CM, FC, DM, AMC, FL, FR, ML, MR};
	public string Name;
	public string FName;
	public Positions Position;
	public Positions SecondaryPosition;
	public int Skill;

	public FPlayer()
	{
		Name = "Afonasiy";
		FName = "Putin";
	//	Position = Position.Random.Range (0, 9);
	//	SecondaryPosition = Position.Random.Range (0, 9);
		Skill = 107;
	}
}
