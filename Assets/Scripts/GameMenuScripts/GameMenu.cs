using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public static GameMenu instance;

	private AudioSource audioSource;	
	public AudioClip backgroundClip;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		_MakeSingleInstance ();
		if (PlayerPrefs.GetInt ("Mute") == 1) {
			AudioListener.volume = 0f;
		} else {
			AudioListener.volume = 1f;
		}
	}

	void _MakeSingleInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (this);
		}
	}

	void FixedUpdate(){
		if(PlayerPrefs.GetInt("Mute")==0 && !audioSource.isPlaying){
			audioSource.PlayOneShot (backgroundClip, 0.3f);
		}
	}
}
