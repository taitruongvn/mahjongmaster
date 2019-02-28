using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	void Awake(){
		_MakeSingleInstance ();
		IsGameStartForTheFirstTime ();
	}

	void IsGameStartForTheFirstTime (){
		if(!PlayerPrefs.HasKey("IsGameStartForTheFirstTime")){
			PlayerPrefs.SetInt ("High Score",0);
			PlayerPrefs.SetInt ("IsGameStartForTheFirstTime",0);
		}
	}

	void _MakeSingleInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (instance);
		}
	}

	public int _GetHighScore(){
		return PlayerPrefs.GetInt ("High Score");
	}

	public void _SetHighScore(int score){
		PlayerPrefs.SetInt ("High Score",score);
	}
}
