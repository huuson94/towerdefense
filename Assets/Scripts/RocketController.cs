using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

    // Config
    public GameObject target;
	public GameObject explosion;		// Prefab of explosion effect.
    public float speed;
	public int damage;
    private TowerGunController controller;
	public float angle;
	private float diffX;
	private float diffY;


	// Use this for initialization
	void Start () {
        // Destroy(gameObject, 3);
	}

    void Awake() 
    {
        // controller = transform.root.GetComponent<TowerController>;
        // controller = transform.root.gameObject.GetComponent<TowerController>;
        // target = GameObject.FindGameObjectWithTag("Enemy");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (target != null)
		{
			diffX = target.transform.position.x - transform.position.x;
			diffY = target.transform.position.y - transform.position.y;
			angle = Mathf.Atan2(diffX, diffY) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, (90 - angle)));
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (speed)*Time.deltaTime);
		}
        else
            Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Enemy")
		{
			Explode();
			Destroy(gameObject);
		}
	}

	void Explode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, target.transform.position, randomRotation);
	}
}
