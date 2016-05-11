using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	private PlayerController player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Health")){
			player.addHealth (20);
			Destroy (col.gameObject);
		}
	}




}
