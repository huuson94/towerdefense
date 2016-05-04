using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour {
	
	public Animator HeaderImage;
	public Animator Play_btn;
	public Animator Setting_dialog;
	public Animator Setting_btn;
	public Animator Facebook_btn;
	public Animator Exit_btn;
	public Slider Main_volumn_slider;
	public Toggle Main_volumn_toggle;
	public Animator Highscore_btn;  	

	public void Update(){
		AudioListener.volume = Main_volumn_slider.value;
	}

	public void MainVolumnToggleChanged(){
		//Debug.Log (Main_volumn_toggle.isOn);
		if (Main_volumn_toggle.isOn == true) {
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		}
	}

	public void MuteGameVolumn(bool Value){
		AudioListener.pause = true;
	}

	public void OpenCustomizeGame(){
		Application.LoadLevel ("CustomizeGame");
	}

	public void OpenInfo(){
		Application.LoadLevel ("CreditScene");
	}

	public void OpenHighScore(){
		Application.LoadLevel ("HighScoresScene");
	}



	public void OpenSetting(){
		//Application.LoadLevel ("Setting");
		HeaderImage.SetBool("isHidden", true);
		Play_btn.SetBool("isHidden", true);
		Setting_btn.SetBool ("isHidden", true);
		Facebook_btn.SetBool ("isHidden", true);
		Exit_btn.SetBool ("isHidden", true);
		Highscore_btn.SetBool ("isHidden", true);
		Setting_dialog.SetBool ("isHidden", false);
	}

	public void CloseSetting(){
		HeaderImage.SetBool("isHidden", false);
		Play_btn.SetBool("isHidden", false);
		Setting_btn.SetBool ("isHidden", false);
		Facebook_btn.SetBool ("isHidden", false);
		Exit_btn.SetBool ("isHidden", false);
		Highscore_btn.SetBool ("isHidden", false);
		Setting_dialog.SetBool ("isHidden", true);
	}

	public void QuitGame(){
		Application.Quit ();

	}
}
