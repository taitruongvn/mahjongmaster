using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour {

	public static SettingManager instance;

	void Awake(){
		_MakeSingleInstance ();
		IsGameStartForTheFirstTime ();
	}

	void IsGameStartForTheFirstTime (){
		if(!PlayerPrefs.HasKey("IsGameStartForTheFirstTime")){
			PlayerPrefs.SetString ("Player Name", "");
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
}
