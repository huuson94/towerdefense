using UnityEngine;
using System.Collections;

public class MenuControlScript : MonoBehaviour {

	public void BackToMainMenu(){
		Application.LoadLevel ("MainMenuScene");
	}
}
