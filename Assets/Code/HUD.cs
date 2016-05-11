using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	private PlayerController player;
	public Text healthText;
	public Text timerText;
	public float timeLeft;


	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		timeLeft = 200;

	}

	void Update(){
		healthText.text = player.currentHealth.ToString ();
		timer ();

	}

	//Game timer
	void timer(){
		timeLeft -= Time.deltaTime;
		timerText.text = timeLeft.ToString ("f0");

		if (timeLeft <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
