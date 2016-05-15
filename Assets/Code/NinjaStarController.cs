using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	PlayerController player;
	GameMaster gm;
	Enemies enemy;
	Animator anim;
	public float speed;
	public GameObject impactEffect; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<Enemies> ();
	

		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}


	//Particle effect for ninjastar impact
	void impactEfect(){
		Instantiate (impactEffect, transform.position, transform.rotation);
	}



	void OnTriggerEnter2D(Collider2D col){

		//Enemy collision
		if(col.CompareTag("Enemy")){

			gm.addPoints (20);
			Destroy (col.gameObject);
			Destroy (this.gameObject);
			impactEfect ();
		}


		else if (col.CompareTag ("Obstacle")) {
			Destroy (this.gameObject);
			impactEfect ();
		}

	}

}
