using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump; 
	public KeyCode action; 

	private Rigidbody2D rb; 

	public float moveSpeed; 
	public float jumpForce; 

	public Animator anim; 


	public Transform groundCheckPoint; 
	public bool isGrounded;
	public float groundCheckRadius; 
	public LayerMask whatIsGround; 


	public Transform wallSensor; 
	public bool isTouchingWall;
	public float wallSensorRadius; 

	//jetpack

	public bool hasJetpack; 
	public float fuel; 
	public float pfuel; 
	public float thrust; 
	public bool jp; 
	public ParticleSystem mainParticle; 





	// Use this for initialization
	void Start () {


		rb = GetComponent<Rigidbody2D> (); 
		anim = GetComponent<Animator> (); 
		hasJetpack = false; 
		pfuel = fuel; 
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement (); 
		
	}



	void Movement()
	{
		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));
		anim.SetBool ("Grounded", isGrounded);
		anim.SetBool ("Jetpack", jp);

		isTouchingWall = Physics2D.OverlapCircle (wallSensor.position, wallSensorRadius, whatIsGround);

		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if (Input.GetKey (left)) {
			if (isTouchingWall && transform.localScale.x == -1) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			} else
				rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);


			
		} else if (Input.GetKey (right)) {
			if (isTouchingWall&& transform.localScale.x == 1) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			}else
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			

		} else {
			rb.velocity = new Vector2 (0, rb.velocity.y);

		}

		if (Input.GetKeyDown (jump) && isGrounded) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
		}


		if (rb.velocity.x < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (rb.velocity.x > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		if (hasJetpack) {
			Jetpack (); 
			ParticleManager (); 
		}
	}


	void Jetpack()
	{
		if (Input.GetKeyUp (jump)) {
			jp = true; 

		}
		if (isGrounded == true) {
			jp = false; 
			pfuel = fuel; 
		}

		if (jp == true && Input.GetKey (jump) && pfuel > 0) {
			rb.AddRelativeForce (Vector2.up * thrust);
			pfuel -= 1f * Time.deltaTime; 
		}


	}

	void ParticleManager()
	{

		if (jp && Input.GetKey (jump) && pfuel > 0) {
			mainParticle.Play (); 
		} else {
			mainParticle.Stop (); 
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "powerup_jetpack") {
			hasJetpack = true; 
			Destroy (other.gameObject);

		}

	}

}
