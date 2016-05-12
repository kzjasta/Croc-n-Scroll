using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	public float speed;
	PlayerController player;
	GameMaster gm;
	public GameObject impactEffect; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		
	}


	void impactEfect(){
		Instantiate (impactEffect, transform.position, transform.rotation);
	}



	void OnTriggerEnter2D(Collider2D col){
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
