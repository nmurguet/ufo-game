using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUnmanned : MonoBehaviour {

	public GameObject dome; 
	public float smooth = 1f;

	public float rotateDome; 

	public bool canMove; 
	// Use this for initialization
	void Start () {
		canMove = false; 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			dome.transform.rotation = Quaternion.Slerp (dome.transform.rotation, Quaternion.Euler (0f, 0f, 70f), rotateDome*Time.deltaTime);


		} else {
			dome.transform.rotation = Quaternion.Slerp (dome.transform.rotation, Quaternion.Euler (0f, 0f, 0f),rotateDome*Time.deltaTime);

		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "player") {
			//dome.gameObject.transform.rotation = Quaternion.Slerp(dome.gameObject.transform.rotation, 
			canMove = true; 
			//dome.transform.rotation = Quaternion.Euler (0f, 0f, 70f); 

		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "player") {
			//dome.gameObject.transform.rotation = Quaternion.Slerp(dome.gameObject.transform.rotation, 
			canMove = false; 
			//dome.transform.rotation = Quaternion.Euler (0f, 0f, 0f); 

		}

	}
}
