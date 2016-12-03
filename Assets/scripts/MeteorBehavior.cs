using UnityEngine;
using System.Collections;

public class MeteorBehavior : MonoBehaviour {
	int meteorSpeed = 6;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.back * meteorSpeed * Time.deltaTime);

		if (transform.position.z < -1.40f) 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "playerWeapon") 
		{
			Destroy (this.gameObject);
		}
		else if (col.gameObject.tag == "Player")
		{
			Destroy (this.gameObject);
			foreach (var clone in GameObject.FindGameObjectsWithTag("Meteor")) 
			{
				Destroy (clone);
			}
		}
	}
}
