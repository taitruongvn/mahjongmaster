using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour {

	public static PlayerName instance;

	public GameObject playerName;

	void Awake(){
		_MakeInstance ();
		playerName.GetComponent<InputField>().placeholder.GetComponent<Text>().text = PlayerPrefs.GetString("Player Name");
	}

	void _MakeInstance(){
		if(instance==null){
			instance = this;
		}
	}

	public void _SubmitName(){
		PlayerPrefs.SetString("Player Name",PlayerName.instance.playerName.GetComponent<InputField>().text);
		SceneManager.LoadScene("GameSetting");
	}

}
