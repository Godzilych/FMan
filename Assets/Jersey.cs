using UnityEngine;
using System.Collections;

public class Jersey : MonoBehaviour
{
	public GameObject Name;
	public GameObject Number;

	public void JerseyUpdate(string NewName, string NewNumber)
	{
		Name.GetComponent<TextMesh>().text = NewName;
		Number.GetComponent<TextMesh>().text = NewNumber;
	}
}
