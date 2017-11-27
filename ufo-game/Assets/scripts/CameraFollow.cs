using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float speed; 

	public bool following; 


	public Vector3 offset;

	// Use this for initialization
	void Start () {

		following = true; 


		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (following == true) {

			if (target) {
				transform.position = Vector3.Lerp (transform.position + offset, target.position, speed); 
			}
		}
		
	}
}
