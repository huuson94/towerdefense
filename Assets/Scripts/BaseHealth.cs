using UnityEngine;
using System.Collections;

public class BaseHealth : MonoBehaviour {

	// Use this for initialization
    public int health = 10;

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            health--;
            Destroy(col.gameObject);
        }
    }
}
