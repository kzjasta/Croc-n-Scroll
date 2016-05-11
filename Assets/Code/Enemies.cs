using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	private GameMaster gm;
	private PlayerController player;

	int health;




	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		health = 100;
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.takeDamage (20);
		}
	}

}
