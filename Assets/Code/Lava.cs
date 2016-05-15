using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	private PlayerController player;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}


	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Player")){
			player.takeDamage(20);
			StartCoroutine (player.kickBack (0.03f, 10));
		}
	}
}
