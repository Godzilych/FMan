using UnityEngine;
using System.Collections;

public class FootbalerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void OnMouseDown()
	{
		GameObject.Find("GameController").GetComponent<GameControllerScript>().PlayerPlacing(this);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
