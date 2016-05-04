using UnityEngine;
using System.Collections;

public class EditModeGridSnap : MonoBehaviour {
	public float snapValue = 1;
	public float depth = 0;
	private Vector3 prevPosition;
	private ArrayList listMap;
	// private int xSize = 13;
	// private int ySize = 7;

	void Init() {
		prevPosition = transform.position;

	}

	void Update() {
		//listMap = new ArrayList<Point>(
	}

	void OnMouseDown() {
		Snap();
		transform.position = prevPosition;
	}

	private void genMap() {

	}

	private void Snap() {
		float x, y, z;
		
		// if snapValue = .5, x = 1.45 -> snapInverse = 2 -> x*2 => 2.90 -> round 2.90 => 3 -> 3/2 => 1.5
		// so 1.45 to nearest .5 is 1.5
		x = 1;// round (transform.position.x);
		y = 2;// round (transform.position.y);
		z = depth;  // depth from camera
		
		transform.position = new Vector3(x, y, z);
	}

	private float round(float f) {
		float snapInverse = 1/snapValue;
		
		return Mathf.Round (f * snapInverse) / snapInverse;
		//return snapValue * Mathf.Round ((f / snapValue));
	}
}

public class Point {
	public int x;
	public int y;

	public Point() {
		this.x = 0;
		this.y = 0;
	}

	public Point(int x, int y) {
		this.x = x;
		this.y = y;
	}
}