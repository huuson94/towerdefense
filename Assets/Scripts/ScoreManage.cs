using UnityEngine;
using System.Collections;

public class ScoreManage : MonoBehaviour {

	public int score = 0;
	public GUIText scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateScore(int value){
		if (value > 0) {
			score += value;
			scoreText.text = "Score: " + score;
			if (score > PlayerPrefs.GetInt ("highestScore")) {
				PlayerPrefs.SetInt ("highestScore", score);
			}
		}
	}
}
