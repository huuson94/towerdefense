using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {
	
	public void BackToMainMenu() {
		Application.LoadLevel ("MainMenuScene");
	}
}
