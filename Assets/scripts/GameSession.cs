using UnityEngine;
using System.Collections;

public class GameSession : MonoBehaviour {
	public GameObject meteorPrefab;
	public GameObject player;
	private double initialSpawnTime = 1.8;
	private double spawnTime;
	private double gameRoundTime = 25.00;
	private int roundCounter = 1;

	// Use this for initialization
	void Start () 
	{
		spawnTime = initialSpawnTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		spawnTime -= Time.deltaTime;
		gameRoundTime -= Time.deltaTime;

		if (spawnTime < 0 && !PlayerControl.isDead)
		{
			Instantiate(meteorPrefab, new Vector3(Random.Range(-4.38f, 4.38f), 0.5f, 15f), Quaternion.identity);
			spawnTime = initialSpawnTime;
		}

		if (gameRoundTime < 0 && !PlayerControl.isDead)
		{
			endRound ();
		}

		if (PlayerControl.isDead && !PlayerControl.waitingForNewGame)
		{
			resetRounds ();
			Debug.Log ("Game Over");
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
		PlayerControl.waitingForNewGame = true;
	}	
}
