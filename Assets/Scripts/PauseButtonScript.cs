using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

	// Config
	public Texture2D pause;
	public Texture2D play;
	public bool isPause = false;
	public GameObject pausePopup;

	public AudioSource buttonClicked;
	// Use this for initialization
	void Start () 
	{
		//pausePopup = GameObject.Find("PauseGamePopup");
		pausePopup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isPause)
		{
			Time.timeScale = 0.0f;
			pausePopup.SetActive(true);
			GetComponent<GUITexture>().texture = pause;
		}
		else
		{
			Time.timeScale = 1.0f;
			pausePopup.SetActive(false);
			GetComponent<GUITexture>().texture = play;
		}
	}

	void OnMouseExit()
	{
		if (isPause)
			GetComponent<GUITexture>().texture = play;
		else
			GetComponent<GUITexture>().texture = pause;
	}

	void OnMouseDown()
	{
		buttonClicked.Play ();
		if (isPause)
			GetComponent<GUITexture>().texture = pause;
		else
			GetComponent<GUITexture>().texture = play;
		isPause = !isPause;
	}
}
