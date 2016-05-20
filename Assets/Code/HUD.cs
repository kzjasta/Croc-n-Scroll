using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	private PlayerController player;
	private GameMaster gm;
	private HUD hud;
	public Text healthText;
	public Text timerText;
	public Text eventText;
	public Text starText;
	public Text livesText;
	public float timeLeft;
	public string levelNumber;



	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		gm = GameObject.FindGameObjectWithTag("Game Master").GetComponent<GameMaster>();
		timeLeft = 60;
		player.starCount = 5;
	}

	void Update(){
		healthText.text = player.currentHealth.ToString ();
		starText.text = player.starCount.ToString ();
		livesText.text = gm.playerLives.ToString ();
		timer ();
	}


	//Game timer
	public void timer(){
		timeLeft -= Time.deltaTime;
		timerText.text = timeLeft.ToString ("f0");

		if (timeLeft <= 0) {
			gm.SaveScore ();
			gm.KillPlayer ();
		}
	}
		
}
