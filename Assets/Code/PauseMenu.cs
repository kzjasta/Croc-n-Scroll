using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;

	void Start(){
		
		PauseUI.SetActive (false);
	}

	void Update(){
		pauseOnOff ();

	}

	//Toggles pause On/Off is "Start" button is pressed
	void pauseOnOff(){
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//Resumes gameplay
	public void Resume(){
		paused = false;
	}

	//Reloads the current scene
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	//Returns player to the main menu
	public void MainMenu(){
		AudioManager.instance.music.Stop ();
		PlayerPrefs.DeleteKey ("Progress");
		SceneManager.LoadScene ("Main Menu");
	}


	//Quits the game
	public void Quit(){
		Application.Quit ();
	}		
}
 	