using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour {
	private int waveCounter = 1;

    // Config
    public float spawnTime;
    public float spawnDelay;

    public float wave1Time;
    public int wave1Number;
    public int wave1Count = 0;

    public float wave2Time;
    public int wave2Number;
    public int wave2Count = 0;

    public float wave3Time;
    public int wave3Number;
    public int wave3Count = 0;

    public float wave4Time;
    public int wave4Number;
    public int wave4Count = 0;

    public float wave5Time;
    public int wave5Number;
    public int wave5Count = 0;

    public GameObject[] enemies;
	public GUIText _guiText;

	// Use this for initialization
	void Start () 
    {
	    // Star calling the spawn function after delay
        InvokeRepeating("SpawnWave1", wave1Time, spawnTime);
	//	Instantiate(enemies [0], transform.position, transform.rotation);
		/*
        InvokeRepeating("SpawnWave2", wave2Time, spawnTime);
        InvokeRepeating("SpawnWave3", wave3Time, spawnTime);
        InvokeRepeating("SpawnWave4", wave4Time, spawnTime);
        InvokeRepeating("SpawnWave5", wave5Time, spawnTime);
        */
		_guiText.text = "WAVE " + waveCounter + "/5";
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(!IsInvoking("SpawnWave1") && waveCounter == 2)
			if(!IsInvoking("SpawnWave2"))
				InvokeRepeating("SpawnWave2", wave2Time, spawnTime);

		if(!IsInvoking("SpawnWave2") && waveCounter == 3)
			if(!IsInvoking("SpawnWave3"))
				InvokeRepeating("SpawnWave3", wave3Time, spawnTime);

		if(!IsInvoking("SpawnWave3") && waveCounter == 4)
			if(!IsInvoking("SpawnWave4"))
				InvokeRepeating("SpawnWave4", wave4Time, spawnTime);

		if(!IsInvoking("SpawnWave4") && waveCounter == 5)
			if(!IsInvoking("SpawnWave5"))
				InvokeRepeating("SpawnWave5", wave5Time, spawnTime);

		if (!IsInvoking ("SpawnWave5") && waveCounter == 6)
			Application.LoadLevel ("WinScene");

	    // Instantiate a random enemy
		if (wave1Count < wave1Number) 
		{
			if(!hasAnyEnemy())
				_guiText.text = "WAVE 1/5";
			waveCounter = 1;
			return;
		}
		if (wave2Count < wave2Number) 
		{
			if(!hasAnyEnemy())
				_guiText.text = "WAVE 2/5";
			waveCounter = 2;
			return;
		}
		if (wave3Count < wave3Number) 
		{
			if(!hasAnyEnemy())
				_guiText.text = "WAVE 3/5";
			waveCounter = 3;
			return;
		}
		if (wave4Count < wave4Number) 
		{
			if(!hasAnyEnemy())
				_guiText.text = "WAVE 4/5";
			waveCounter = 4;
			return;
		}
		if (wave5Count < wave5Number) 
		{
			if(!hasAnyEnemy())
				_guiText.text = "WAVE 5/5";
			waveCounter = 5;
			return;
		}
		waveCounter = 6;
	}

    void SpawnWave1() 
    {
        if (wave1Count >= wave1Number) {
			if(hasAnyEnemy())
				return;
			CancelInvoke("SpawnWave1");
			return;
		}
        wave1Count++;
        int enemyIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies [enemyIndex], transform.position, transform.rotation);
		//Debug.Log (transform.rotation);
		//Debug.Log (enemies [enemyIndex].transform.position);
    }
     
    void SpawnWave2() 
    {
        if (wave2Count >= wave2Number) {
			if(hasAnyEnemy())
				return;
			CancelInvoke("SpawnWave2");
			return;
		}
        wave2Count++;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies [enemyIndex], transform.position, transform.rotation);
		Debug.Log (enemies [enemyIndex].transform.position);
    }

    void SpawnWave3() 
    {
        if (wave3Count >= wave3Number) {
			if(hasAnyEnemy())
				return;
			CancelInvoke("SpawnWave3");
			return;
		}
        wave3Count++;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies [enemyIndex], transform.position, transform.rotation);

    }

    void SpawnWave4() 
    {
		if (wave4Count >= wave4Number) {
			if(hasAnyEnemy())
				return;
			CancelInvoke("SpawnWave4");
			return;
		}
        wave4Count++;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies [enemyIndex], transform.position, transform.rotation);

    }

    void SpawnWave5() 
    {
		if (wave5Count >= wave5Number) {
			if(hasAnyEnemy())
				return;
			
			CancelInvoke("SpawnWave5");
			return;
		}
        wave5Count++;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies [enemyIndex], transform.position, transform.rotation);

    }

	private bool hasAnyEnemy() {
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if(gameObj.name == "Zombie_easy(Clone)" || gameObj.name == "Zombie_hard(Clone)")
			{
				return true;
			}
		}
		return false;
	}
}
