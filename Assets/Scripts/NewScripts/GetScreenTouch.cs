using UnityEngine;
using System.Collections;

public class GetScreenTouch : MonoBehaviour {
	public Vector3 currentPos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			currentPos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
			var hitColiders = Physics.OverlapSphere(currentPos, 1f);

			//for( int i = 0; i < hitColiders.Length; i++)
			foreach(var collider in hitColiders)
			{
				Debug.Log(currentPos.x + " and " + currentPos.y);

			}
			//if(Input.
		}
		//if (Input.touchCount != 0) {
		//	var touch = Input.GetTouch(0);

		//}
	}
}
