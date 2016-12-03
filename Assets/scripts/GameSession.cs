using UnityEngine;
using System.Collections;

public class GameSession : MonoBehaviour 
{
	const double overHeatTime = 3.0;
	double initialSpawnTime = 1.8;
	double spawnTime;
	double gameRoundTime = 25.00;
	int roundCounter = 1;
	double weaponOverHeatTime = overHeatTime;
	int shootsToOverHeat = 10;
	int shootCounter = 0;
	bool weaponCooling = false;

	public static bool isDead = false;
	public static bool waitingForNewGame = false;

	public GameObject meteorPrefab;
	public GameObject playerObj;
	public GameObject shootObj;

	// Use this for initialization
	void Start () 
	{
		spawnTime = initialSpawnTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (weaponCooling) 
		{
			weaponOverHeatTime -= Time.deltaTime;
			if (weaponOverHeatTime < 0) 
			{
				weaponOverHeatTime = overHeatTime;
				weaponCooling = false;
			}
		}

		spawnTime -= Time.deltaTime;
		gameRoundTime -= Time.deltaTime;

		if (spawnTime < 0 && !isDead)
		{
			Instantiate(meteorPrefab, new Vector3(Random.Range(-4.38f, 4.38f), 0.5f, 15f), Quaternion.identity);
			spawnTime = initialSpawnTime;
		}

		if (gameRoundTime < 0 && !isDead)
		{
			endRound ();
		}

		if (isDead && !waitingForNewGame)
		{
			resetRounds ();
			Debug.Log ("Game Over");
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) 
		{ 
			if (shootCounter < shootsToOverHeat && !weaponCooling) 
			{
				shootCounter += 1;
				Instantiate (
					shootObj,
					playerObj.transform.position,
					Quaternion.identity
				);
			}
			else
			{
				shootCounter = 0;
				weaponCooling = true;
			}
		}
	}

	void endRound ()
	{
		gameRoundTime = 30.0d;
		roundCounter += 1;
		initialSpawnTime -= 0.1d;
		Debug.Log ("Round: " + roundCounter);
		Debug.Log ("Spawn-time: " + initialSpawnTime);
	}


	void resetRounds ()
	{
		gameRoundTime = 30.0d;
		initialSpawnTime = 5.0d;
		roundCounter = 0;
		waitingForNewGame = true;
	}
}
