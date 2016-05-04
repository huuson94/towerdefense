using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {
	//public Texture2D pressed;
	//public Texture2D released;

	public void OpenCustomizeGame(){
		Application.LoadLevel ("CustomizeGame");
	}

}
