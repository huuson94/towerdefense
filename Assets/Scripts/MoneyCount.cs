using UnityEngine;
using System.Collections;

public class MoneyCount : MonoBehaviour {
	
	public int money = 1000;
	public GUIText _guiText;

	//public GameObject[] towers;
	// Use this for initialization
	void Start () {
		_guiText = GameObject.Find ("MoneyTxt").GetComponent<GUIText>();
		_guiText.text = "$ " + money;
		SetCanSelectTower ();
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
		SetCanSelectTower ();
	}

	private void SetCanSelectTower(){
		GameObject[] towerButtons = GameObject.FindGameObjectsWithTag ("TowerButton");
		foreach(GameObject towerButton in towerButtons){
			float towerCost = towerButton.GetComponent<GuiTextureControl> ().tower.GetComponent<DragTower> ().towerCost;
			if ((float)money < towerCost) {
				Color colorT = towerButton.GetComponent<GUITexture> ().color;
				colorT.a = 0.16f;
				towerButton.GetComponent<GUITexture> ().color = colorT;
				//towerButton.set
			} else {
				Color colorT = towerButton.GetComponent<GUITexture> ().color;
				colorT.a = 1f;
				towerButton.GetComponent<GUITexture> ().color = colorT;
			}
		}
	}
}