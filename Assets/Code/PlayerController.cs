using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameMaster gm;
	public HUD hud;
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
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
		hud = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUD> ();


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
		if(grounded && Input.GetButtonDown("Jump")){
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


	//Kills the player in game
	void KillPlayer(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	public void takeDamage(int dmg){
		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("RedFlash");
	}

	//Adds
	public void addHealth(int health){
		currentHealth += health;
	}

	void checkHealth(){	
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) {
			KillPlayer (); 
		}
			
	}

	//Knocks the player backwards
	public IEnumerator kickBack(float knockDur, float knockPwr, Vector3 knockDir){

		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;

			player.AddForce (new Vector3 (knockDir.x * -10, knockDir.y * knockPwr, transform.position.z));
		}

		yield return 0;
	}

	//Checks for possible colisions
	void OnTriggerEnter2D(Collider2D col){
		healthPickup (col);
		gemPickup (col);
		floorLimit (col);
		exit (col);
	}


	//Collision detection for health pickup
	void healthPickup(Collider2D col){
		if (col.CompareTag ("Health")) {
			addHealth (20);
			gm.addPoints (10);
			Destroy (col.gameObject);
		}
	}

	//Collision detection for gem pickup
	void gemPickup(Collider2D col){
		if (col.CompareTag ("Gem")) {
			gm.addPoints (100);
			Destroy (col.gameObject);
		}
	}


	//Collision for floor limits
	void floorLimit(Collider2D col){
		if (col.CompareTag ("Floor Limit")) {
			KillPlayer ();
		}
	}

	//Collision for exit
	void exit(Collider2D col){
		if (col.CompareTag("Exit")){
			gm.SaveScore ();
			gm.nextLevel ();
		}
	}
}
