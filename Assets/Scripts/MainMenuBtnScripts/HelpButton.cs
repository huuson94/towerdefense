using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Help(){
		Application.LoadLevel ("HelpScene");
	}
}
