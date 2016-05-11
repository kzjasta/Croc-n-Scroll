using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject MainMenuUI;
	public GameObject ControlsUI;

	void Start(){
		MainMenuUI.SetActive (true);
		ControlsUI.SetActive (false);
			
	}


	//Starts the game at the beginning
	public void StartGame(){
		SceneManager.LoadScene ("Level 1");
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
}

