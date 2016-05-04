using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ChooseMaps : MonoBehaviour {
	
	public Toggle map1;
	public Toggle map2;
	public Toggle map3;

	public Toggle easy;
	public Toggle medium;
	public Toggle insane;



	public void Start(){
		map1.isOn = true;
		easy.isOn = true;
	}

	public void BackToMainMenu(){
		Application.LoadLevel ("MainMenuScene");
	}

	public void ChooseMap1(){
		if (map1.isOn) {
			UnCheckAllMapsExcept ("map1");
		}
		//map1.isOn = true;
	}

	public void ChooseMap2(){
		if (map2.isOn) {
			UnCheckAllMapsExcept ("map2");
		}
	}

	public void ChooseMap3(){
		if (map3.isOn) {
			UnCheckAllMapsExcept ("map3");
		}
	}

	public void ChooseEasy(){
		if (easy.isOn) {
			UnCheckAllLevelsExcept ("easy");
		}
	}

	public void ChooseMedium(){
		if (medium.isOn) {
			UnCheckAllLevelsExcept ("medium");
		}
	}

	public void ChooseInsane(){
		if (insane.isOn) {
			UnCheckAllLevelsExcept ("insane");
		}
	}

	private void UnCheckAllMapsExcept(string map){
		switch (map) {
		case "map1":
			map2.isOn = false;
			map3.isOn = false;
			break;
		case "map2":
			map1.isOn = false;
			map3.isOn = false;
			break;
		case "map3":
			map1.isOn = false;
			map2.isOn = false;
			break;
		default:
			break;
		}
	}

	private void UnCheckAllLevelsExcept(string level){
		switch (level) {
		case "easy":
			medium.isOn = false;
			insane.isOn = false;
			break;
		case "medium":
			easy.isOn = false;
			insane.isOn = false;
			break;
		case "insane":
			easy.isOn = false;
			medium.isOn = false;
			break;
		default:
			break;
		}
	}

	public void GotoGameScene(){
		if (map1.isOn) {
			if(easy.isOn)
				Application.LoadLevel ("Level1");
			if(medium.isOn)
				Application.LoadLevel ("Level1Med");
			if(insane.isOn)
				Application.LoadLevel ("Level1Insane");
		} else if (map2.isOn) {
			if(easy.isOn)
				Application.LoadLevel ("Level2");
			if(medium.isOn)
				Application.LoadLevel ("Level2Med");
			if(insane.isOn)
				Application.LoadLevel ("Level2Insane");
		} else {
			if(easy.isOn)
				Application.LoadLevel ("Level3");
			if(medium.isOn)
				Application.LoadLevel ("Level3Med");
			if(insane.isOn)
				Application.LoadLevel ("Level3Insane");
		}

	}
}
