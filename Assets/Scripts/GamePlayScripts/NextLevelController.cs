using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour {

	public void NextLevel2(){

			Time.timeScale = 1;
			SceneManager.LoadScene (GamePlay.instance.NextLevel);
	}
}
