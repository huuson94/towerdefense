using UnityEngine;
using System.Collections;

public class GuiTextureControl : MonoBehaviour {

	public Texture2D normal;
	public Texture2D press;

	public GameObject tower;						// Tower generation
	public bool flag = false;
	public bool canPlaceTower = false;
	public GameObject money; // TODO: get the money from the screen here :3
	public AudioSource buttonClicked;

	// Use this for initialization
	void Start () 
	{
		GetComponent<GUITexture>().texture = normal;
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void OnMouseDown(){
		
		GetComponent<GUITexture>().texture = press;
		if (!flag)
		{
			// Debug.Log("Touch");
			// Instantiate(tower, transform.position, transform.rotation);
			flag = true;
			canPlaceTower = true;
		}

		//GameObject.Find("MoneyTxt").guiText.text = "" + money;

	}

	void FixedUpdate()
	{
		flag = false;
		if (Input.GetMouseButtonDown(0))
		{
			//buttonClicked.Play ();
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (canPlaceTower)
			{
				Instantiate(tower, new Vector3(mousePosition.x, mousePosition.y, 0), transform.rotation);
				Debug.Log ("1"+tower.transform.position);
				canPlaceTower = false;
				GetComponent<GUITexture>().texture = normal;
			}

		}

	}


}
