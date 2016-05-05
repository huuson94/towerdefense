using UnityEngine;
using System.Collections;

public class Map3Script : MonoBehaviour {
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

	public void removeCell(float x, float y) {
		foreach (MyPoint point in this.blockCell) {
			if(point.Equals(new MyPoint(x, y))) {
				blockCell.Remove(point);
			}
		}
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
		createHorizontalLineBlock (-7f, -4f, 1f);
		createVerticalLineBlock (1f, 3f, -4f);
		createHorizontalLineBlock (-4f, -1f, 3f);
		createVerticalLineBlock (-2f, 3f, -2f);
		createVerticalLineBlock (-2f, 3f, -1f);
		createVerticalLineBlock (-2f, 3f, 0f);
		createVerticalLineBlock (-2f, 3f, 1f);
		createVerticalLineBlock (-2f, 3f, 2f);
		createHorizontalLineBlock (1f, 4f, 3f);
		createVerticalLineBlock (1f, 3f, 4f);
		createHorizontalLineBlock (4f, 7f, 1f);
		createVerticalLineBlock (-2f, 1f, 6f);
		createVerticalLineBlock (-2f, 1f, 7f);
		addBlockCell (-3f, -1f);
		addBlockCell (3f, -2f);
		addBlockCell (-5f, 2f);
		addBlockCell (-5f, -1f);
		addBlockCell (5f, -1f);
		addBlockCell (5f, 3f);
	}
}
