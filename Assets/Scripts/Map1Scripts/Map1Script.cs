using UnityEngine;
using System.Collections;

public class Map1Script : MonoBehaviour {
	public ArrayList blockCell;

	void Awake() {
		blockCell = new ArrayList ();
		addBlockCell ();
	}
	// Use this for initialization
	void Start () {

	}

	public void addBlockCell(float x, float y) {
		this.blockCell.Add (new MyPoint (x, y));
	}
	//only accept vertical or horizontal line
	private void createVerticalLineBlock(float start, float end, float hori){
		float i = -100;
		for (i = start; i <= end; i++) {
			addBlockCell (hori, i);
		}	
	}

	private void createHorizontalLineBlock(float start, float end, float vert){
		float i = -100;
		for (i = start; i <= end; i++) {
			addBlockCell (i, vert);
		}	
	}

	private void addBlockCell() {
		float i = -8f;
		float j = -4f;

		createHorizontalLineBlock (-9, -5, -2);
		createHorizontalLineBlock (-9, -5, -3);
		createVerticalLineBlock (-3, 1, -4);
		createVerticalLineBlock (-3, 1, -5);
		createHorizontalLineBlock (-4, -1, 1);
		createHorizontalLineBlock (-1, 2, 2);
		createHorizontalLineBlock (2, 6, 3);
		createHorizontalLineBlock (2, 6, 4);
		createVerticalLineBlock (-1, 3, 5);
		createVerticalLineBlock (-1, 3, 6);
		createHorizontalLineBlock (6, 8, 0);
		createHorizontalLineBlock (6, 8, -1);
		//add trees
		addBlockCell (-7f, 2f);
		addBlockCell (-5f, 4f);
		addBlockCell (-2f, 4f);
		addBlockCell (-3f, -3f);
		addBlockCell (2f, -1f);
		addBlockCell (3f, -3f);
		addBlockCell (8f, 2f);
		//add info, button
		createHorizontalLineBlock (-9f, 5f, -4f);
		createHorizontalLineBlock (-9f, 5f, -5f);
		createHorizontalLineBlock (-5f, 5f, 4f);
		createHorizontalLineBlock (-5f, 5f, 5f);
	}
}

public class MyPoint {
	public float x;
	public float y;

	public MyPoint() {
		this.x = 0f;
		this.y = 0f;
	}

	public MyPoint(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public bool Equals(MyPoint compare) {
		if (this.x == compare.x && this.y == compare.y)
			return true;

		return false;
	}
}
