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
		levelNumber = "Level " + SceneManager.GetActiveScene ().buildIndex.ToString();
		timeLeft = 100;
		StartCoroutine (showMessage (showLevel(), 3));
	}

	void Update(){
		healthText.text = player.currentHealth.ToString ();
		starText.text = player.starCount.ToString ();
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

	//Displays level number on screen
	public IEnumerator showMessage(string message, float delay){
		eventText.text = message;
		eventText.enabled = true;
		yield return new WaitForSeconds (3);
		eventText.enabled = false;
	}

	//Returns a string containing the current level 
	string showLevel(){
		return levelNumber;
	}
}
