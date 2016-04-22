using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D player;
	private Animator anim;
	public float maxSpeed = 15f;
	bool facingRight = true;
	public float jumpForce = 800f;

	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		Physics.IgnoreLayerCollision (8,9);

	}

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundcheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("verticalSpeed", player.velocity.y);


		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));

		player.velocity = new Vector2 (move * maxSpeed, player.velocity.y);

		if (move > 0 && !facingRight)
			FlipSprite ();
		else if (move < 0 && facingRight)
			FlipSprite ();
	}

	void Update(){

		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("Ground", false);
			player.AddForce(new Vector2(0, jumpForce));
		}
	}

	// Flips the direction of the sprite
	void FlipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
