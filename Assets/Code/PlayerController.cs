using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


	private Rigidbody2D player;
	private Animator anim;
	public float maxSpeed = 15f;
	bool facingRight = true;
	public float jumpForce = 800f;

	//Ground checker
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//Player Health
	public int currentHealth;
	public int maxHealth = 100;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;

	}

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundcheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("verticalSpeed", player.velocity.y);


		float move = Input.GetAxisRaw ("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));

		player.velocity = new Vector2 (move * maxSpeed, player.velocity.y);

		if (move > 0 && !facingRight)
			FlipSprite ();
		else if (move < 0 && facingRight)
			FlipSprite ();
	}

	void Update(){

		checkHealth ();

		// If player is on the ground, allow to jump
		if(grounded && Input.GetButton("Jump")){
			anim.SetBool ("Ground", false);
			player.AddForce(new Vector2(0, jumpForce / 5));

		}
	}

	// Flips the direction of the sprite
	void FlipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	//Kills the player in game
	void KillPlayer(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	void checkHealth(){	
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) {
			KillPlayer (); 
		}
			
	}
}
