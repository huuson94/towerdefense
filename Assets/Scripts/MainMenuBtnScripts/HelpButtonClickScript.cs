using UnityEngine;
using System.Collections;

public class HelpButtonClickScript : MonoBehaviour {
	public Texture2D help;
	public Texture2D helpOnPressed;

	// Use this for initialization
	void Start () {
		GetComponent<GUITexture>().texture = help;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GetComponent<GUITexture>().texture = helpOnPressed;
	}

	void OnMouseUp() {
		GetComponent<GUITexture>().texture = help;
		Application.LoadLevel ("HelpScene");
	}
}
