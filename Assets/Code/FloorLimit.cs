using UnityEngine;
using System.Collections;

public class FloorLimit : MonoBehaviour {

	GameMaster gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Game Master").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnTriggerEnter2D(Collider2D col){
		checkFallen (col);
	}

	void checkFallen(Collider2D col){
		if(col.CompareTag("LimitChecker")){
			
			gm.KillPlayer ();
		}
	}
}
