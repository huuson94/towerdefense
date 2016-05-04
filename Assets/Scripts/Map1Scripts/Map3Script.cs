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
	
	private void addBlockCell() {
		float i = -8f;
		float j = -5f;
		
		while(i <= 7f) {
			while(j <= 4f) {
				if(i == -8f || i == 7f 
				   || i == -7f || i == 6f) {
					addBlockCell(i, j);
				}
				if(j == -5f || j == 4f
				   || j == -3f || j == 3f) {
					addBlockCell(i, j);
				}
				
				j = j + 1f;
			}
			j = -5f;
			i = i + 1f;
		}


		addBlockCell (-6f, 1f);
		addBlockCell (-5f, 1f);
		addBlockCell (-4f, 1f);
		addBlockCell (-4f, 2f);
		addBlockCell (-1f, 2f);
		addBlockCell (-2f, 2f);
		addBlockCell (-2f, 1f);
		addBlockCell (-2f, 0f);
		addBlockCell (-2f, -1f);
		addBlockCell (-1f, -1f);
		addBlockCell (0f, -1f);
		addBlockCell (1f, -1f);
		addBlockCell (1f, 0f);
		addBlockCell (1f, 1f);
		addBlockCell (1f, 2f);
		addBlockCell (0f, 2f);

		addBlockCell (3f, 2f);
		addBlockCell (3f, 1f);
		addBlockCell (4f, 1f);
		addBlockCell (5f, 1f);
		addBlockCell (5f, 0f);
		
	}
}
