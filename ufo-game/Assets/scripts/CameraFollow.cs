using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float speed; 

	public float speedChange; 

	public bool following; 


	public Vector3 offset;


	public Vector3 offset_ship;

	public Vector3 offset_walker; 

	public bool onWalker;

	public bool change; 

	public Ufo ufo; 
	public float maxSpeed; 
	public float maxZoom; 
	public float minZoom; 

	// Use this for initialization
	void Start () {

		following = true; 
		change = false; 
		offset_walker = offset; 
		offset_ship = offset;
		offset_ship.y = 0f;
		onWalker = true; 

		minZoom = Camera.main.orthographicSize;

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (following == true) {

			if (target) {
				transform.position = Vector3.Lerp (transform.position + offset, target.position, speed); 
			}
		}


		if (ufo.getSpeed > maxSpeed) {
			Camera.main.orthographicSize +=2f * Time.deltaTime; 

		} else if (ufo.getSpeed < maxSpeed) {
			Camera.main.orthographicSize -= 2f * Time.deltaTime; 
		}

		if (Camera.main.orthographicSize > maxZoom) {
			Camera.main.orthographicSize = maxZoom;
		}
		if (Camera.main.orthographicSize < minZoom) {
			Camera.main.orthographicSize = minZoom;
		}
		
	}




	public void ChangeTarget(Transform tar)
	{
		target = tar;

	}

	void Update()
	{
		if (change && onWalker) {
			offset = Vector3.Lerp (offset, offset_walker, speedChange);


		} else if (change && !onWalker) {
			offset = Vector3.Lerp (offset, offset_ship, speedChange);
		}


	}

	public void ChangeOffset()
	{
		if (onWalker) {
			//offset = Vector3.Lerp (offset, offset_ship, speed);
			//offset = offset_ship;
			StartCoroutine(waitandCancel(3f));
			change = true;
			onWalker = false; 

		} else {
			//offset = offset_walker;
			StartCoroutine(waitandCancel(3f));
			change = true; 
			onWalker = true; 
		}


	}

	IEnumerator waitandCancel(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		change = false;
		if (onWalker) {
			offset = offset_walker;
		} else {
			offset = offset_ship;
		}
	}



}
