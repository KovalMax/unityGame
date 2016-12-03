using UnityEngine;
using System.Collections;

public class ShootBehavior : MonoBehaviour
{
	int shootSpeed = 4;

	public GameObject weaponShotPrefab;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.forward * shootSpeed * Time.deltaTime);

		if (transform.position.z > 20.40f) 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Meteor")
		{
			Destroy (this.gameObject);
		}
	}
}
