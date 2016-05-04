using UnityEngine;
using System.Collections;

public class LivesCounter : MonoBehaviour {
	
	private int lives = 10;
	public GUIText _guiText;
	// Use this for initialization
	void Start () {
		_guiText.text = "LIVES " + lives;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives >= 0) {
			_guiText.text = "LIVES " + lives;
		} else {
			_guiText.text = "LIVES 0";
			Application.LoadLevel("LoseScene");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy")
		{
			lives--;
		}
	}
}