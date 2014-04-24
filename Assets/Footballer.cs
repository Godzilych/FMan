using UnityEngine;
using System.Collections;

public class Footballer : MonoBehaviour
{
	public enum PositionList {LD,CD,RD,DM,LW,RW,CM,LM,LR,AMC,AML,AMR,FC,RF,LF};
	public string Name;
	public PositionList Position;
	[Range(0.0f,200.0f)]public int Skill;

	public Footballer (string NewName, int NewSkill)
	{
		Name = NewName;
		Skill = NewSkill;
	}
}
