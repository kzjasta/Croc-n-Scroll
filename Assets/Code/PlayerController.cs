using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameMaster gm;
	public HUD hud;
	public Enemies enemy;
	private Rigidbody2D player;
	private Animator anim;
	public Transform stompCheck;
	public float maxSpeed = 15f;
	bool facingRight = true;
	public float jumpForce = 800f;
	public int starCount;

	//Ground checker
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//Projectiles
	public Transform firePoint;
	public GameObject ninjaStar;

	//Player Health
	public int currentHealth;
	public int maxHealth = 100;

	//Audio Clips
	public AudioClip jumpSound;
	public AudioClip shootSound;
	public AudioClip gemSound;
	public AudioClip healthSound;
	public AudioClip burnSound;
	public AudioClip killSound;
	public AudioClip hurtSound;
	public AudioClip finishSound;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
		hud = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUD> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<Enemies> ();
		starCount = 5;


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
		fireProjectile ();
		checkHealth ();
		jump ();
	}



	//If player is grounded, allow to jump
	void jump(){
		if(grounded && Input.GetButtonDown("Jump")){
			anim.SetBool ("Ground", false);
			player.AddForce(new Vector2(0, jumpForce));
			AudioManager.instance.PlaySingle (jumpSound);
		}
	}

	// Flips the direction of the sprite
	void FlipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	//Deals damage to the player
	public void takeDamage(int dmg){
		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("RedFlash");
	}

	//Adds health to the players current health
	public void addHealth(int health){
		currentHealth += health;
	}


	//Checks to see if the player is dead
	void checkHealth(){	
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) {
			gm.KillPlayer (); 
		}
			
	}

	//Knocks the player backwards
	public IEnumerator kickBack(float knockDur, float knockPwr){
		float timer = 0;

		if(knockDur > timer) {
			player.velocity = new Vector2 (-knockPwr, knockPwr);
		}

		yield return 0;
	}

	//Checks for possible colisions
	void OnTriggerEnter2D(Collider2D col){
		healthPickup (col);
		gemPickup (col);
		enemyStomp (col);
		enemyCollision (col);
		lavaBurn (col);
	}


	//Collision detection for health pickup
	void healthPickup(Collider2D col){
		if (col.CompareTag ("Health")) {
			AudioManager.instance.PlaySingle (healthSound);
			addHealth (20);
			gm.addPoints (10);
			Destroy (col.gameObject);
		}
	}

	//Collision detection for gem pickup
	void gemPickup(Collider2D col){
		if (col.CompareTag ("Gem")) {
			AudioManager.instance.PlaySingle (gemSound);
			gm.addPoints (100);
			Destroy (col.gameObject);
		}
	}


	//Collision for floor limits
	void floorLimit(Collider2D col){
		if (col.CompareTag ("Floor Limit")) {
			gm.KillPlayer ();
		}
	}

	//Collision for stomping an enemy
	void enemyStomp(Collider2D col){
		if(col.CompareTag("Stomp Checker")){
			AudioManager.instance.PlaySingle (killSound);
			StartCoroutine (kickBack (0.03f, 10));
			Destroy (col.transform.parent.gameObject);
			gm.addPoints (50);
		}
	}

	//Collision for an enemy
	void enemyCollision(Collider2D col){
		if(col.CompareTag("Enemy")){
			AudioManager.instance.PlaySingle (hurtSound);
			takeDamage(20);
			StartCoroutine (kickBack (50, 10));
		}
	}

	//Collision for lava
	void lavaBurn(Collider2D col){
		if(col.CompareTag("Lava")){
			AudioManager.instance.PlaySingle (burnSound);
			takeDamage(20);
			StartCoroutine (kickBack (50, 10));
		}
	}
		

	//Player fires a projectile
	void fireProjectile(){
		if (Input.GetButtonDown ("Fire") && starCount > 0){
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			AudioManager.instance.PlaySingle (shootSound);
			starCount--;
		}
	}




}
	