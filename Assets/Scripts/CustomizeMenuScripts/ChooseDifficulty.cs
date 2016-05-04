using UnityEngine;
using System.Collections;

public class ChooseDifficulty : MonoBehaviour {
	public bool isSet = false;
	public Texture2D chooseTexture;
	public Texture2D defaultTexture;
	
	// Use this for initialization
	void Start () {
		GetComponent<GUITexture>().texture = defaultTexture;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSet) {
			GetComponent<GUITexture>().texture = chooseTexture;
		} else {
			GetComponent<GUITexture>().texture = defaultTexture;
		}
	}
	
	void OnMouseUp() {
		this.isSet = true;
		
		if (!this.gameObject.Equals(GameObject.Find ("DifEasy"))) {
			GameObject.Find("DifEasy").GetComponent<ChooseDifficulty>().isSet = false;
		}
		if (!this.gameObject.Equals(GameObject.Find ("DifMedium"))) {
			GameObject.Find("DifMedium").GetComponent<ChooseDifficulty>().isSet = false;
		}
		if (!this.gameObject.Equals(GameObject.Find ("DifInsane"))) {
			GameObject.Find("DifInsane").GetComponent<ChooseDifficulty>().isSet = false;
		}
	}
}
