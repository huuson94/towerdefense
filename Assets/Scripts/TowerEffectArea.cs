using UnityEngine;
using System.Collections;

public class TowerEffectArea : MonoBehaviour {

	// Config
	//public GameObject areaImage;//can place image
	//public GameObject areaImageError; //can not place image
	public Vector2 positionOffset;
	public float areaRadius;
	public GameObject effectArea;
	public GameObject effectAreaError;
	public bool onClickFlag = false;
	public bool canDrag = false;
	// Use this for initialization
	void Start () 
	{
		effectArea = Instantiate(effectArea, transform.position + new Vector3(positionOffset.x, positionOffset.y, 1),
		                         transform.rotation) as GameObject;
		effectAreaError = Instantiate(effectAreaError, transform.position + new Vector3(positionOffset.x, positionOffset.y, 1),
			transform.rotation) as GameObject;
		effectArea.transform.localScale = new Vector3(areaRadius * 0.8f, areaRadius * 0.8f, 0);
	//	effectAreaError.transform.localScale = new Vector3(areaRadius * 0.8f, areaRadius * 0.8f, 0);
		effectArea.SetActive(false);
	//	effectAreaError.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		effectArea.transform.position = transform.position + new Vector3(positionOffset.x, positionOffset.y, 1);
		effectAreaError.transform.position = transform.position + new Vector3(positionOffset.x, positionOffset.y, 1);

	}
}
