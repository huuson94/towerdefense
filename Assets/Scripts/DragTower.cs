using UnityEngine;
using System.Collections;

public class DragTower : MonoBehaviour {
    
    // public SpringJoint2D spring;
    public bool canDrag = false;
	public bool isDragging = false;
	public bool clickOnThis = false;
	public Vector3 screenPoint;
	GameObject blockCells;
	GameObject towerAoe;

	// For snapping to grid
	private Vector3 prevPoint;
	private float snapValue = 1;
	private bool isEnoughMoneyVar = true;
	public float depth = 0;
	private ArrayList blockedCellsList;
	private MyPoint position;
	private bool selfDestruction = false;
	private bool isDragged = false;

	public float towerCost;

	public int mouseUpCount = 0;

    void Awake()
    {
		prevPoint = transform.position;
		//blockedCellsList = GameObject.Find ("BlockCellsController").GetComponent<Map1Script> ().blockCell;
    }
    
	void Start()
	{
		
		//blockCells = GameObject.FindGameObjectWithTag ("BlockCellsController");
		try {
			if(Application.loadedLevelName == "Level1") {
				//Debug.Log ("Boom");
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level2") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level3") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level1Med") {
				//Debug.Log ("Boom");
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level2Med") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level3Med") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
			}
			if(Application.loadedLevelName == "Level1Insane") {
				//Debug.Log ("Boom");
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level2Insane") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
			}
			else if(Application.loadedLevelName == "Level3Insane") {
				blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
			}
			//blockedCellsList = blockCells.GetComponent<Map1Script> ().blockCell;
		} catch(UnityException) {

		}
        towerAoe = gameObject.GetComponent<TowerEffectArea> ().effectArea;
	}
    
    void OnMouseDown()
    {
		if (mouseUpCount >= 1)
			return;
       	screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//updateMoney ();
		if (!isEnoughMoney ()) {
			//Destroy (gameObject);
			selfDestruction = true;
			isEnoughMoneyVar = false;
		} else
		{
			selfDestruction = false;
			isEnoughMoneyVar = true;
		}
    }
    
    
    void OnMouseDrag()     
    {
		//Debug.Log (transform.position);
		if (mouseUpCount >= 1)
			return;
		isDragging = true;
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x,
                                                 Input.mousePosition.y,
												screenPoint.z);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);

        transform.position = currentPos;
	}

    void OnMouseUp()     
    {
		if (mouseUpCount >= 1) {
			//if(GameObject.Find ("UpgradeBtn").GetComponent<UpgradeBtnScript>().buttonPress) {
				//clickOnThis = !clickOnThis;
			//}
			//if(GameObject.Find ("SellBtn").GetComponent<SellBtnScript>().buttonPress) {
			//	clickOnThis = false;
           //     selfDestruction = true;
			//}
			mouseUpCount++;
			return;
		}

		isDragging = false;
		Snap ();
		mouseUpCount++;
		isDragged = true;

    }

	// For snapping to grid
	private void Snap() {
		float x, y, z;
		// if snapValue = .5, x = 1.45 -> snapInverse = 2 -> x*2 => 2.90 -> round 2.90 => 3 -> 3/2 => 1.5
		// so 1.45 to nearest .5 is 1.5
		x = Round (transform.position.x);
		y = Round (transform.position.y);
		z = depth;  // depth from camera
		position = new MyPoint (x, y);
		if (checkCellBlock (position)) {
			//transform.position = new Vector3 (x + 0.5f, y, z);
			//prevPoint = transform.position;
			//Debug.Log("not ok"+x+","+y);

			//Debug.Log (gameObject.transform.parent);
			//Destroy(gameObject);
			selfDestruction = true;
		} else {
			clickOnThis = false;

			blockedCellsList.Add(new MyPoint(x, y));
			descreaseMoney ();
			//Debug.Log ("ok" + x + "," + y);
			//return;
		}
		//setEffectArea (position);
		return;
	}
	void Update() 
	{
		if (selfDestruction)
		{
			Destroy(gameObject);
		}
		position = new MyPoint (Round (transform.position.x), Round (transform.position.y));

		if (isDragged) {
			gameObject.GetComponent<TowerEffectArea>().effectArea.SetActive(false);
			gameObject.GetComponent<TowerEffectArea>().effectAreaError.SetActive(false);

		} else if(isEnoughMoneyVar){
			setEffectArea (position);
		}
		if (!isEnoughMoneyVar) {
			gameObject.GetComponent<TowerEffectArea> ().effectArea.SetActive (false);
			gameObject.GetComponent<TowerEffectArea> ().effectAreaError.SetActive (false);
		} else {
			
		}
	}

	private void setEffectArea(MyPoint point){
		if (checkCellBlock(point)) {
			gameObject.GetComponent<TowerEffectArea>().effectArea.SetActive(false);
			gameObject.GetComponent<TowerEffectArea>().effectAreaError.SetActive(true);
		} else {
			gameObject.GetComponent<TowerEffectArea>().effectArea.SetActive(true);
			gameObject.GetComponent<TowerEffectArea>().effectAreaError.SetActive(false);
		}
	}


	private bool isEnoughMoney(){
		int money = GameObject.Find("Main Camera").GetComponent<MoneyCount>().money;
		if (money < towerCost) {
			return false;
		}
		return true;
	}

	private void descreaseMoney() {
		//Debug.Log (this.gameObject.name);

		int money = GameObject.Find("Main Camera").GetComponent<MoneyCount>().money;
		GameObject.Find ("Main Camera").GetComponent<MoneyCount> ().updateMoney (-(int)towerCost);

	}

	//return true if this place can not placed
	private bool checkCellBlock(MyPoint cell) {
		if (blockedCellsList == null)
			return false;

		foreach (MyPoint point in blockedCellsList) {
			if(point.Equals(cell)) {
				return true;
			}
		}
		return false;
	}
    
	private float Round(float f) {
		return snapValue * Mathf.Round ((f / snapValue));
	}


	private void checkMap() {
		if(Application.loadedLevelName == "Level1") {

			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level2") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level3") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level1Med") {
			//Debug.Log ("Boom");
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level2Med") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level3Med") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
		}
		if(Application.loadedLevelName == "Level1Insane") {
			//Debug.Log ("Boom");
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map1Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level2Insane") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map2Script> ().blockCell;
		}
		else if(Application.loadedLevelName == "Level3Insane") {
			blockedCellsList = GameObject.Find ("Main Camera").GetComponent<Map3Script> ().blockCell;
		}
	}

}