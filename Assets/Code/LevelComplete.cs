using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelComplete : MonoBehaviour {

	public AudioClip finishSound;
	public Text pointsText;

	// Use this for initialization
	void Start () {
		AudioManager.instance.PlaySingle (finishSound);
		showPoints (GetScore());
	}
	
	// Update is called once per frame
	void Update () {
		Continue ();
	}

	void Continue(){
		if(Input.GetButtonDown("Jump")){
			Debug.Log (PlayerPrefs.GetInt("Progress"));
			SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("Progress"));
			AudioManager.instance.music.Play ();
		}
	}


	//Sets points text object to value of points
	void showPoints(int points){
		pointsText.text = points.ToString ();
	}

	int GetScore(){
		int score = PlayerPrefs.GetInt ("Score");
		return score;
	}
		
}
