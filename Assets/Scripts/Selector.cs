using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void OnMouseDown()
	{
		GameObject.Find("GameController").GetComponent<GameControllerScript>().PlayerPlacing(this);
	}

}
