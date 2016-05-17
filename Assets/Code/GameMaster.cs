using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

	public int points;
	public Text pointsText;
	public Text eventText;
	public int levelNumber;
	public int progressNumber;
	public float timeLeft;
	public AudioClip dieSound;
	public PlayerController player;
	public Transform SpawnPoint;
	public int playerLives;

	void Start(){
		AudioManager.instance.music.Play ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		playerLives = 3;
		timeLeft = 60;
		getScore ();
		progressNumber = SceneManager.GetActiveScene ().buildIndex;
		SaveProgress ();
		StartCoroutine (showMessage (progressNumber.ToString(), 3));
		Debug.Log(PlayerPrefs.GetInt ("Progress"));
	}

	//Kills the player in game
	public void KillPlayer(){
		loseLive ();
		if (playerLives <= 0) {
			Reset ();
			SceneManager.LoadScene ("GameOver");
		} else {
			AudioManager.instance.PlaySingle (dieSound);
			RespawnPlayer ();
		}
	}

	//Restarts the player at the respawn point
	public void RespawnPlayer(){
		player.transform.position = SpawnPoint.transform.position;
		player.currentHealth = 100;
	}

	//If level 1, delete score, otherwise get score
	void getScore(){
		if (PlayerPrefs.HasKey ("Score")) {
			if (SceneManager.GetActiveScene ().buildIndex == 1) {
				PlayerPrefs.DeleteKey ("Score");
				points = 0;
			} else {
				points = PlayerPrefs.GetInt ("Score");
			}
		}
	}

	void Update(){
		pointsText.text = (points.ToString()); 
	}

	//Adds points to the score
	public void addPoints(int pnts){
		points += pnts;
	}

	//Removes a live
	public void loseLive(){
		playerLives--;
	}


	//Saves the players current score
	public void SaveScore(){
		PlayerPrefs.SetInt ("Score", points);
	}

	//Saves the players progress
	public void SaveProgress(){
		if (progressNumber == 1) {
			PlayerPrefs.SetInt ("Progress", levelNumber);
		} else {
			PlayerPrefs.DeleteKey ("Progress");
		}
		PlayerPrefs.SetInt ("Progress", progressNumber);
	}
		

	//Displays messeage on screen
	public IEnumerator showMessage(string message, float delay){
		eventText.text = "Level " + message;
		eventText.enabled = true;
		yield return new WaitForSeconds (3);
		eventText.enabled = false;
	}

	void Reset(){
		PlayerPrefs.DeleteKey ("Progress");
		PlayerPrefs.DeleteKey ("Score");
	}
}
