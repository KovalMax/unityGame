using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	private int playerSpeed = 6;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.RightArrow) && transform.position.x < 4.38f)
		{
			transform.Translate (Vector3.right * playerSpeed * Time.deltaTime);
		} 
		else if (Input.GetKey (KeyCode.LeftArrow) && transform.position.x > -4.38f) 
		{
			transform.Translate (Vector3.left * playerSpeed * Time.deltaTime);
		}

		if (GameSession.isDead && Input.GetKey (KeyCode.Space))
		{
			restartGame ();			
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Meteor") 
		{
			GameSession.isDead = true;
		}
	}

	public static void restartGame() 
	{
		GameSession.isDead = false;
		GameSession.waitingForNewGame = false;
		Debug.Log ("Starting New Game");
	}
}
