using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	private PlayerController player;
	public Text healthText;
	public Text timerText;
	public float timeLeft;
	public Text eventText;
	public Text starText;
	public string levelNumber;



	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		timeLeft = 60;
	}

	void Update(){
		healthText.text = player.currentHealth.ToString ();
		starText.text = player.starCount.ToString ();
		timer ();
	}

	public void test(){
		Debug.Log ("WORKING");
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
