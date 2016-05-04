using UnityEngine;
using System.Collections;

public class TowerButtonScript : MonoBehaviour {

	// Config
	public GameObject tower;
	public Texture2D normal;
	public Texture2D press;
	public bool isPressed = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		if (!isPressed)
		{
			isPressed = true;
			GetComponent<GUITexture>().texture = press;
		}
		else
			isPressed = false;
	}

	void OnMouseExit()
	{

	}
}
