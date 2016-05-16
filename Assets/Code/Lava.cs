using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	private PlayerController player;

	public AudioClip burnSound;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}


	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Lava")){
			AudioManager.instance.PlaySingle (burnSound);
			player.takeDamage(20);
			StartCoroutine (player.kickBack (0.03f, 10));
		}
	}
}
