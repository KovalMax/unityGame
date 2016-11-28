using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private int playerSpeed = 6;
	public static bool isDead = false;
	public static bool waitingForNewGame = false;
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
		} else if (Input.GetKey (KeyCode.LeftArrow) && transform.position.x > -4.38f) 
		{
			transform.Translate (Vector3.left * playerSpeed * Time.deltaTime);
		}

		if (isDead && Input.GetKey (KeyCode.Space))
		{
			restartGame ();			
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Meteor") 
		{
			isDead = true;
		}
	}

	public static void restartGame() 
	{
		isDead = false;
		waitingForNewGame = false;
		Debug.Log ("Starting New Game");
	}
}
