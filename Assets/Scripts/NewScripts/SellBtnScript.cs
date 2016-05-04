using UnityEngine;
using System.Collections;

public class SellBtnScript : MonoBehaviour {

	public Texture2D enable;
	public Texture2D disable;
	
	public bool buttonPress = false;
	
	// Use this for initialization
	void Start () 
	{
		GetComponent<GUITexture>().texture = disable;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		GetComponent<GUITexture>().texture = enable;
	}
	
	void OnMouseUp()
	{
		GetComponent<GUITexture>().texture = disable;
		buttonPress = !buttonPress;
		GameObject.Find("UpgradeBtn").GetComponent<UpgradeBtnScript>().buttonPress = false;
	}
}
