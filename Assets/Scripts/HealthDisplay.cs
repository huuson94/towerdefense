using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	// Use this for initialization

	public GameObject tower;
	public int health;
	private GUIText healthText;

	void Start () 
	{
		healthText = gameObject.GetComponent<GUIText>();
		Debug.Log("Start game");
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.health = tower.GetComponent<BaseHealth>().health;
		healthText.text = this.health.ToString();
	}
}
