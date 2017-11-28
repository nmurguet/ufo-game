using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Walker walker;
	public Ufo ufo;
	public GameObject ufo_unmanned; 
	public CameraFollow myCam; 

	public bool onShip;

	public Transform spawnPoint; 


	// Use this for initialization
	void Start () {
		walker = FindObjectOfType<Walker>(); 
		myCam = FindObjectOfType<CameraFollow> (); 
		ufo = FindObjectOfType<Ufo> (); 
		ufo_unmanned = GameObject.Find ("shipUnmanned"); 

		walker.transform.position = spawnPoint.position; 
		ufo.gameObject.SetActive (false); 
		onShip = false; 

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		
	}


	public void EnterShip()
	{
		if (!onShip) {
			ufo.transform.position = ufo_unmanned.transform.position;
			ufo_unmanned.SetActive (false);
			ufo.gameObject.SetActive (true); 
			walker.gameObject.SetActive (false); 
			StartCoroutine (waitandLaunch (1.5f));
			myCam.ChangeTarget (ufo.transform);
			onShip = true; 
		}


	}

	public void ExitShip()
	{
		if (onShip) {
			ufo_unmanned.transform.position = ufo.transform.position;
			ufo_unmanned.SetActive (true);
			ufo.gameObject.SetActive (false); 
			walker.transform.position = ufo.transform.position;
			walker.gameObject.SetActive (true); 
			myCam.ChangeTarget (walker.transform);
			onShip = false; 
		}


	}

	IEnumerator waitandLaunch(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		ufo.canFly = true;
	}

}
