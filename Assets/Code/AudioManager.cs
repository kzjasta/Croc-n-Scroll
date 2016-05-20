using UnityEngine;
using System.Collections;

//Code derived from Unity audio tutorials
public class AudioManager : MonoBehaviour {

	public AudioSource effect;
	public AudioSource music;
	public static AudioManager instance = null;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject); 
	}


	//Plays a single audio clip
	public void PlaySingle(AudioClip clip){
		effect.clip = clip;
		effect.Play ();
	}
		
}
