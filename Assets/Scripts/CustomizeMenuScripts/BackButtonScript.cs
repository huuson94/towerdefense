using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {
	public Texture2D pressed;
	public Texture2D released;

	// Use this for initialization
	void Start () {
		GetComponent<GUITexture>().texture = released;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GetComponent<GUITexture>().texture = pressed;
	}

	void OnMouseUp() {
		GetComponent<GUITexture>().texture = released;
		Application.LoadLevel ("MainMenuScene");
	}
}
