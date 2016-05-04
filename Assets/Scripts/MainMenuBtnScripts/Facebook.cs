using UnityEngine;
using System.Collections;

public class Facebook : MonoBehaviour {
	
	private string facebookAddress = "https://www.facebook.com/xoan2512";

	public void OpenFacebookPage ()
	{
		float startTime;
		startTime = Time.timeSinceLevelLoad;

		if (Time.timeSinceLevelLoad - startTime <= 1f)
		{
			//fail. Open safari.
			Application.OpenURL(facebookAddress);
		}
	}

}
