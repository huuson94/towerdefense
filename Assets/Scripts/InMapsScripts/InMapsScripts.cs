using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InMapsScripts : MonoBehaviour {

	public Animator pauseDialog;
	public bool isPause = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	IEnumerator WaitForPauseDialog(float timeScale)
	{
		yield return new WaitForSeconds (0.5f);
		Time.timeScale = timeScale;
	}

	public void OpenPauseDialog(){
		pauseDialog.enabled = true;
		pauseDialog.SetBool("isHidden", true);
		StartCoroutine(WaitForPauseDialog(0.0f));
	}

	public void ClosePauseDialog(){ 
		Time.timeScale = 1.0f;
		pauseDialog.SetBool("isHidden", false);
	}
}
