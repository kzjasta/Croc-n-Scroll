using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

	public int points;
	public Text pointsText;
	private int levelsCompleted;
	private HUD hud;
	public Text eventText;
	public string levelNumber;

	void Start(){
		getScore ();
		levelNumber = "Level " + SceneManager.GetActiveScene ().buildIndex.ToString();
		StartCoroutine (showMessage (showLevel(), 3));
	}

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


	public void addPoints(int pnts){
		points += pnts;
	}


	//Saves the players current score
	public void SaveScore(){
		PlayerPrefs.SetInt ("Score", points);
	}

	//Adds 
	public void progressTracker(){
		levelsCompleted++;
	}


	//Loads the next level in the build index
	public void nextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	//Calculates the total score
	public void calcScore(float timeLeft){
		points += Mathf.FloorToInt (timeLeft);
		Debug.Log (points);

	}

	//Displays messeage on screen
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
