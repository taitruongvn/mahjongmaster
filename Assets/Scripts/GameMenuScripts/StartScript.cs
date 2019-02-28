using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	public void _StartGame(){
		SceneManager.LoadScene("SelectLevel");
	}

	public void _OpenSetting(){
		SceneManager.LoadScene ("GameSetting");
	}

	public void _OpenHighScore(){
		SceneManager.LoadScene ("HighScore");

	}

	public void _Quit(){
		Application.Quit ();
	}

}
