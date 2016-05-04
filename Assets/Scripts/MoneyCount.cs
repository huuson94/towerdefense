using UnityEngine;
using System.Collections;

public class MoneyCount : MonoBehaviour {
	
	public int money = 1000;
	public GUIText _guiText;
	// Use this for initialization
	void Start () {
		_guiText = GameObject.Find ("MoneyTxt").GetComponent<GUIText>();
		_guiText.text = "$ " + money;
	}
	
	// Update is called once per frame
	void Update () {
		if (money >= 0) {
			_guiText.text = "$ " + money;
		} else {
			_guiText.text = "$ 0";
		}
		
	}
	
	public void updateMoney(int changeMoney) {
		if (money + changeMoney >= 0) {
			money += changeMoney;
		}
	}
}