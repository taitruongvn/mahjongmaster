using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelController : MonoBehaviour {

	public int level = 0;

	public void _StartLevel(){
		SceneManager.LoadScene (level);
	}

	public void _ResetLevel(){
		PlayerPrefs.SetInt ("Level Pass",1);
		SceneManager.LoadScene ("SelectLevel");
	}

	public void _BackToMenu(){
		SceneManager.LoadScene ("GameMenu");
	}
}
