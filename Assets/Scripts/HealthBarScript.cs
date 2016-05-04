using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	private Vector3 healthScale;			// Health bar scale
	private SpriteRenderer healthBar;		// Sprite renderer
	private int originalHealth;
	private int currentHealth;
	public float scale;

	// Use this for initialization
	void Start () 
	{
		healthScale = transform.localScale;
		healthBar = gameObject.GetComponent<SpriteRenderer>();
		originalHealth = transform.root.gameObject.GetComponent<EnemyMovement>().health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentHealth = transform.root.gameObject.GetComponent<EnemyMovement>().health;
		scale = (float)currentHealth / originalHealth;
		// Set the health bar's colour to proportion of the way between green and red based on the player's health
		healthBar.color = Color.Lerp(Color.red, Color.green, scale);
		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * scale, healthScale.y, healthScale.z);
	}
}
