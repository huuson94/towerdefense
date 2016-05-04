using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuControlScript : MonoBehaviour {
	public Text scoreText;

	public void BackToMainMenu(){
		Application.LoadLevel ("MainMenuScene");
	}

	public void Start(){
		if (PlayerPrefs.HasKey ("highestScore")) {
			scoreText.text = PlayerPrefs.GetInt ("highestScore").ToString ();
		} else {
			scoreText.text = "0";
		}	
	}
}
