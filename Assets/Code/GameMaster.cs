using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

	public int points;
	public Text pointsText;
	private int levelsCompleted;


	void Start(){
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




}
