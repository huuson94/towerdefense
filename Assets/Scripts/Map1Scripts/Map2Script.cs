using UnityEngine;
using System.Collections;

public class Map2Script : MonoBehaviour {
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
		createHorizontalLineBlock (-9f, -5f, 2f);
		createHorizontalLineBlock (-9f, -5f, 3f);
		createVerticalLineBlock (-3f, 3f, -6f);
		createVerticalLineBlock (-3f, 3f, -5f);
		createHorizontalLineBlock (-6f, -2f, -1f);
		createHorizontalLineBlock (-6f, -2f, -2f);
		createVerticalLineBlock (-3f, 3f, -2f);
		createVerticalLineBlock (-3f, 3f, -3f);
		createHorizontalLineBlock (-3f, 3f, 1f);
		createHorizontalLineBlock (-3f, 3f, 2f);
		createVerticalLineBlock (-3f, 3f, 1f);
		createVerticalLineBlock (-3f, 3f, 2f);
		createHorizontalLineBlock (2f, 6f, -1f);
		createHorizontalLineBlock (2f, 6f, -2f);
		createVerticalLineBlock (-2f, 1f, 5f);
		createHorizontalLineBlock (6f, 8f, 1f);
		addBlockCell (2f, -4f);
		addBlockCell (7f, -3f);
		addBlockCell (4f, -1f);
		addBlockCell (-4f, 1f);
		addBlockCell (-7f, -1f);
		addBlockCell (1f, 3f);
		addBlockCell (7f, 2f);
		//add info, button
		createHorizontalLineBlock (-9f, 5f, -4f);
		createHorizontalLineBlock (-9f, 5f, -5f);
		createHorizontalLineBlock (-5f, 5f, 4f);
		createHorizontalLineBlock (-5f, 5f, 5f);
	}
}