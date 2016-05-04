using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Config
	public float destroyTime;
	
	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, destroyTime);	
	}
}
