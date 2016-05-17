﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	GameMaster gm;
	public int finalScore;
	public Text score;
	public AudioClip dieSound;
	// Use this for initialization
	void Start () {
		AudioManager.instance.music.Stop ();
		AudioManager.instance.PlaySingle (dieSound);
		finalScore = PlayerPrefs.GetInt("Score");
		score.text = finalScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			SceneManager.LoadScene ("Main Menu");
		}
	}
}