using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour {

	public AudioClip finishSound;
	public Text pointsText;
	public GameMaster gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
		AudioManager.instance.PlaySingle (finishSound);
		showPoints (GetScore());
	}
	
	// Update is called once per frame
	void Update () {
		Continue ();
	}


	//Loads the main menu
	void Continue(){
		if(Input.GetButtonDown("Jump")){
			SceneManager.LoadScene ("Main Menu");
		}
	}

	//Sets points text object to value of points
	void showPoints(int points){
		pointsText.text = points.ToString ();
	}

	//Returns the player score
	int GetScore(){
		int score = PlayerPrefs.GetInt ("Score");
		return score;
	}
}


