using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour 
{
	public static HighScoreManager instance;

	void Awake(){
		_MakeSingleInstance ();
		HighScoreTable ();
	}

	public void HighScoreTable (){
		if(!PlayerPrefs.HasKey("HighScoreTable")){
			PlayerPrefs.SetString("HighScoreName"+1,"");
			PlayerPrefs.SetInt ("HighScoreScore"+1,0);
			PlayerPrefs.SetString("HighScoreName"+2,"");
			PlayerPrefs.SetInt ("HighScoreScore"+2,0);
			PlayerPrefs.SetString("HighScoreName"+3,"");
			PlayerPrefs.SetInt ("HighScoreScore"+3,0);
			PlayerPrefs.SetString("HighScoreName"+4,"");
			PlayerPrefs.SetInt ("HighScoreScore"+4,0);
			PlayerPrefs.SetString("HighScoreName"+5,"");
			PlayerPrefs.SetInt ("HighScoreScore"+5,0);
			PlayerPrefs.SetString("HighScoreName"+6,"");
			PlayerPrefs.SetInt ("HighScoreScore"+6,0);
			PlayerPrefs.SetInt ("HighScoreTable",0);
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