using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject MainMenuUI;
	public GameObject ControlsUI;
	public GameMaster gm;

	void Start(){
		MainMenuUI.SetActive (true);
		ControlsUI.SetActive (false);
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
		gm.playerLives = 3;
	}

	void Update(){
		if(Input.GetButtonDown("Cancel")){
			Back();
		}
	}


	//Starts the game at the beginning
	public void StartGame(){
		SceneManager.LoadScene ("Level 1");
		gm.Reset ();
	}

	//Displays the game controls page
	public void ShowControls(){
		if (MainMenuUI.activeInHierarchy) {
			MainMenuUI.SetActive (false);
			ControlsUI.SetActive (true);
		} else {
			MainMenuUI.SetActive (true);
			ControlsUI.SetActive (false);
		}
	}

	//Exits the application
	public void QuitGame(){
		Application.Quit ();
	}

	//Return to main menu
	public void Back(){
		if (ControlsUI.activeInHierarchy){
			ControlsUI.SetActive (false);
			MainMenuUI.SetActive (true);
		}
	}
}

