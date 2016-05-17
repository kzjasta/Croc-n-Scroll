using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	GameMaster gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			gm.progressNumber++;
			gm.addPoints (500);
			gm.SaveProgress ();
			gm.SaveScore ();
			AudioManager.instance.music.Stop ();	
			SceneManager.LoadScene ("LevelComplete");
		}
	}
		
}
