using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float runSpeed = 21f;
	public Vector3 velocity;
	private Animator _animator;
	public string moveDirection;					// right, left, up, down
    public int health = 3;
	public GameObject slowEffect;
	public bool isSlow = false;
	public GameObject slowEffectInstance;
	public string object_name;
	public int score;
	public int money;
	// Use this for initialization
	void Start () 
	{
		_animator = GetComponent<Animator>();
		if(this.gameObject.name == "Zombie_easy(Clone)") {
			object_name = "zombie_easy";
		}
		if(this.gameObject.name == "Zombie_hard(Clone)") {
			object_name = "zombie_hard";
		}

	}
	
    void OnTriggerEnter2D (Collider2D other)
    {
        // If the enemy hit the redirection point
        if (other.tag == "Redirect")
        {
            moveDirection = other.gameObject.GetComponent<RedirectController>().direction;
        } 
        
		if (other.tag == "FinishPoint")
        {
            Destroy(gameObject);
        }
        
		if (other.tag == "TowerBullet")
        {
			health -= other.gameObject.GetComponent<RocketController>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);

				updateMoney();
				updateScore ();
            }
        }

		if (other.tag == "SlowBullet" && !isSlow)
		{
			runSpeed = runSpeed / 2;
			isSlow = true;
			slowEffectInstance = Instantiate(slowEffect, transform.position, transform.rotation) as GameObject;
			Invoke("ClearSlowEffect", 2);
		}
    }

	private void updateMoney() {
		if(this.gameObject.name == "Enemy(Clone)") {
			GameObject.Find ("Main Camera").GetComponent<MoneyCount> ().updateMoney (money);
		}
		if(this.gameObject.name == "Zombie_easy(Clone)") {
			GameObject.Find ("Main Camera").GetComponent<MoneyCount> ().updateMoney (money);
		}
		if(this.gameObject.name == "Zombie_hard(Clone)") {
			GameObject.Find ("Main Camera").GetComponent<MoneyCount> ().updateMoney (money);
		}
	}

	private void updateScore(){
		if (score > 0) {
			GameObject.Find ("Main Camera").GetComponent<ScoreManage> ().updateScore (gameObject.GetComponent<EnemyMovement>().score);
		}
	}

	// Update is called once per frame
	void Update () 
	{	
		if (slowEffectInstance != null)
		{
			slowEffectInstance.transform.position = transform.position + new Vector3(0, 0, -1);
		}

		if (moveDirection == "right") 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, 0);
			_animator.Play( Animator.StringToHash( object_name+"_right" ));
		}
		else if (moveDirection == "left") 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, 0);
			_animator.Play( Animator.StringToHash( object_name+"_left" ));
		}
		else if (moveDirection == "up") 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, runSpeed);
			_animator.Play( Animator.StringToHash( object_name+"_up" ));
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, -runSpeed);
			_animator.Play( Animator.StringToHash( object_name+"_down" ));
		}
	}

	void ClearSlowEffect()
	{
		isSlow = false;
		runSpeed = runSpeed * 2;
		Destroy(slowEffectInstance);
	}

	private void MapController() {
		if(Application.loadedLevelName == "5") {
			//blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "6") {
			//blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "7") {
			//blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
		}
	}
}
