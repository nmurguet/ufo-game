using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Walker walker;
	public Ufo ufo;

	public Transform spawnPoint; 


	// Use this for initialization
	void Start () {
		walker = FindObjectOfType<Walker>(); 
		ufo = FindObjectOfType<Ufo> (); 

		walker.transform.position = spawnPoint.position; 


	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
