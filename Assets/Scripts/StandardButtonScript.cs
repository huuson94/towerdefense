using UnityEngine;
using System.Collections;

public class StandardButtonScript : MonoBehaviour {

    // Config
    public Texture2D normal;
    public Texture2D press;
	public string sceneName;
	private GameObject pauseButton;

	public AudioSource buttonClicked;

	// Use this for initialization
	void Start () 
    {
        GetComponent<GUITexture>().texture = normal;
		pauseButton = GameObject.Find("PauseBtn");
	}
	
	// Update is called once per frame

	void OnMouseDown () 
	{
		GetComponent<GUITexture>().texture = press;
		try {
		if (sceneName != null)
			Application.LoadLevel(sceneName);
		}
		catch(UnityException) {

		}
		pauseButton.GetComponent<PauseButtonScript>().isPause = false;
	}

	void OnMouseExit () 
	{
		GetComponent<GUITexture>().texture = normal;
	}
}
