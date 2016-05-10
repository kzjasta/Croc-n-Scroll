using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	private PlayerController player;
	public Text healthText;


	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();

	}

	void Update(){
		healthText.text = player.currentHealth.ToString ();
	}
}
