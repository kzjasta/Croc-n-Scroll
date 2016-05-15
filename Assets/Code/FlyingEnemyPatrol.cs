using UnityEngine;
using System.Collections;

public class FlyingEnemyPatrol : MonoBehaviour {


	private PlayerController player;

	public float speed;
	public float playerDistance;
	public LayerMask playerDetect;
	public bool inRange;
	public bool facingRight;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();


	}
	
	// Update is called once per frame
	void Update () {
		detectPlayer ();

	}

	// Flips the direction of the sprite
	void FlipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	//Draws detections sphere
	void OnDrawGizmosSelected(){
		Gizmos.DrawSphere (transform.position, playerDistance);	
	}

	//Detects if player is in range
	void detectPlayer(){
		inRange = Physics2D.OverlapCircle (transform.position, playerDistance, playerDetect);

		if (inRange) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed*Time.deltaTime);
		}
	}
}
