using UnityEngine;
using System.Collections;

public class Twitter : MonoBehaviour {
	public Texture2D twitter;
	public Texture2D twitterOnPressed;
	private string twitterAddress = "https://twitter.com/Team092";
	// Use this for initialization
	void Start () {
		GetComponent<GUITexture>().texture = twitter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GetComponent<GUITexture>().texture = twitterOnPressed;
	}

	void OnMouseUp() {
		GetComponent<GUITexture>().texture = twitter;
		OpenTwitterPage ();
	}

	void OpenTwitterPage ()
	{
		float startTime;
		startTime = Time.timeSinceLevelLoad;
		//open the facebook app
		Application.OpenURL(twitterAddress);
	}
}
