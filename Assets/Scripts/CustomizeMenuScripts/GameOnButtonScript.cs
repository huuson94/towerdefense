using UnityEngine;
using System.Collections;

enum Utility {
	NONE = 0,
	EASY1 = 1,
	EASY2 = 2,
	EASY3 = 3,
	MEDIUM1 = 4,
	MEDIUM2 = 5,
	MEDIUM3 = 6,
	INSANE1 = 7,
	INSANE2 = 8,
	INSANE3 = 9,
};

public class GameOnButtonScript : MonoBehaviour {
	
	void Start () {
	}
	
	void OnMouseDown() {
	}
	
	void OnMouseUp() {
		controlLevel ();
	}

	void controlLevel() {
		switch (utilityFunction ()) {
		case Utility.EASY1:
			Application.LoadLevel("Level1");
			break;
		case Utility.EASY2:
			Application.LoadLevel("Level2");
			break;
		case Utility.EASY3:
			Application.LoadLevel("Level3");
			break;
		case Utility.MEDIUM1:
			Application.LoadLevel("Level1Med");
			break;
		case Utility.MEDIUM2:
			Application.LoadLevel("Level2Med");
			break;
		case Utility.MEDIUM3:
			Application.LoadLevel("Level3Med");
			break;
		case Utility.INSANE1:
			Application.LoadLevel("Level1Insane");
			break;
		case Utility.INSANE2:
			Application.LoadLevel("Level2Insane");
			break;
		case Utility.INSANE3:
			Application.LoadLevel("Level3Insane");
			break;
		default:
			break;
		}
	}

	private Utility utilityFunction() {
		
		return Utility.NONE;
	}
}
