using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelManager : MonoBehaviour {

	public static SelectLevelManager instance; 

	void Awake(){
		_MakeSingleInstance ();
		IsLevelPassed ();
		TempScore ();
	}

	void IsLevelPassed (){
		if(!PlayerPrefs.HasKey("IsLevelPassed")){
			PlayerPrefs.SetInt ("Level Pass",1);
			PlayerPrefs.SetInt ("IsLevelPassed",0);
		}
	}

	void TempScore()
	{
		PlayerPrefs.SetInt ("TempScore",0);
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

