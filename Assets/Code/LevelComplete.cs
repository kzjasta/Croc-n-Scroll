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

		showPoints (PlayerPrefs.GetInt("Score"));
	}
	
	// Update is called once per frame
	void Update () {
		Continue ();
	}

	void Continue(){
		if(Input.GetButtonDown("Jump")){
			//checkNextLevel ();
			Application.Quit();
		}
	}


	//Sets points text object to value of points
	void showPoints(int points){
		pointsText.text = points.ToString ();
	}


	//Checks what level to load next
	void checkNextLevel(){
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			SceneManager.LoadScene ("Level 1");
			//Debug.Log (SceneManager.GetActiveScene);
		}
		else if(SceneManager.GetActiveScene().buildIndex == 2){
			SceneManager.LoadScene ("Level 2");
		}
	}
}
